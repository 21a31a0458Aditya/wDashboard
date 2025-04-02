using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[Route("api/favorites")]
[ApiController]
public class FavoritesController : ControllerBase
{
    private readonly string filePath = "favorites.json"; // File to store favorites

    // Load existing favorites from the JSON file
    private List<string> LoadFavorites()
    {
        if (!System.IO.File.Exists(filePath))
        {
            return new List<string>();
        }
        var json = System.IO.File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }

    // Save favorites to JSON file
    private void SaveFavorites(List<string> favorites)
    {
        var json = JsonSerializer.Serialize(favorites);
        System.IO.File.WriteAllText(filePath, json);
    }

    // GET: Retrieve all favorite locations
    [HttpGet]
    public ActionResult<List<string>> GetFavorites()
    {
        return LoadFavorites();
    }

    // POST: Add a city to favorites
    [HttpPost]
    public ActionResult AddFavorite([FromBody] string city)
    {
        var favorites = LoadFavorites();
        if (!favorites.Contains(city))
        {
            favorites.Add(city);
            SaveFavorites(favorites);
        }
        return Ok();
    }

    // DELETE: Remove a city from favorites
    [HttpDelete("{city}")]
    public ActionResult RemoveFavorite(string city)
    {
        var favorites = LoadFavorites();
        favorites.Remove(city);
        SaveFavorites(favorites);
        return Ok();
    }
}
