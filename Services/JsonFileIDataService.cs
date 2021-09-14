using Mansoura.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mansoura.Services
{
    public class JsonFileIDataService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Data.json"); }
        }
        public JsonFileIDataService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public Members GetMembers()
        {
            using (var jsonFile=File.OpenText(JsonFileName))
            {
                var jsonString = jsonFile.ReadToEnd();
                return JsonSerializer.Deserialize<Members>(jsonString);
            } 
        }

        public void AddRating(int memberId , int Rating)
        {
            var list = GetMembers();
            var member = list.MemberList.Where(s => s.Owner.UserId == memberId).Select(s => s).FirstOrDefault();
            if(member!= null)
            {
                if (member.Rating == null)
                    member.Rating = new int[] { Rating };
                else
                {
                    var ratingList = member.Rating.ToList();
                    ratingList.Add(Rating);
                    member.Rating = ratingList.ToArray();
                } 
            }

            using (var stream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<Members>(new Utf8JsonWriter(stream, new JsonWriterOptions()
                {
                    SkipValidation = true,
                    Indented = true
                }), list);
            }
        }

        
    }
}
