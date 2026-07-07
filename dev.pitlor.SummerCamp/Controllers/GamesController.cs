using System.IO.Compression;
using System.Text.Json;
using dev.pitlor.SummerCamp.Decks;
using dev.pitlor.SummerCamp.Decks.Custom;
using dev.pitlor.SummerCamp.Models;
using dev.pitlor.SummerCamp.Services;
using Microsoft.AspNetCore.Mvc;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController(GamesService gamesService) : ControllerBase
{
    [Route("upload-decks")]
    [HttpPost]
    public IActionResult UploadDecks([FromForm] FormFile file)
    {
        using var stream = file.OpenReadStream();
        using var zip = new ZipArchive(stream);

        var configEntry = zip.GetEntry("config.json");
        if (configEntry == null)
        {
            return BadRequest("Missing config.json");
        }

        using var configStream = configEntry.Open();
        var config = JsonSerializer.Deserialize<CustomDeckConfig>(configStream);
        if (config == null)
        {
            return BadRequest("Malformed config.json");
        }

        var cardImageReader = ImageToBase64(zip, "cards");
        var badgeImageReader = ImageToBase64(zip, "badges");
        var storeCards = config.StoreCards
            .Select(x => new Tuple<int, Card>(x.Count, CustomCard.Create(x.Card, cardImageReader)))
            .ToArray();
        var move1Card = CustomCard.Create(config.Move1Card, cardImageReader);
        var badges = config.Badges
            .Select(b => new Badge(badgeImageReader(b.ImagePath), b.Points))
            .ToList();

        var deck = new Deck(Path.Custom(config.Name), move1Card, badges, DeckFactory.OfCards(storeCards));
        gamesService.AddCustomDeck(config.Name, deck);
        
        return Ok();
    }

    private static Func<string, string> ImageToBase64(ZipArchive zipArchive, string folder) => path =>
    {
        var image = zipArchive.GetEntry($"{folder}/{path}");
        if (image == null)
        {
            return "data:image/png;base64";
        }
        
        using var stream = image.Open();
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);

        return "data:image/png;base64" + Convert.ToBase64String(memoryStream.ToArray());
    };
}