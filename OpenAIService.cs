using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;

namespace WhatRoleAmI.API.Services
{
    public class OpenAIService
    {
        private readonly GenerativeModel _model;

        public OpenAIService(IConfiguration config)
        {
            var apiKey = config["Gemini:Key"];
            var google = new GoogleAI(apiKey!);
            _model = google.GenerativeModel("gemini-2.0-flash");
        }
        public async Task<string> AnalyzeAnswers(List<string> answers)
        {
            await Task.Delay(500);

            return """
    [
        {
            "role": "Full Stack .NET Developer",
            "match": 92,
            "why": "Your answers show a strong balance between backend logic and frontend polish. You thrive in end-to-end ownership of features.",
            "skills": ["ASP.NET Core", "React", "SQL Server", "Azure"],
            "emoji": "🧑‍💻"
        },
        {
            "role": "Backend API Engineer",
            "match": 85,
            "why": "You gravitate toward system design and API architecture. You care deeply about reliability and performance under load.",
            "skills": ["C#", "REST APIs", "Entity Framework", "Microservices"],
            "emoji": "⚙️"
        },
        {
            "role": "Cloud Solutions Developer",
            "match": 78,
            "why": "Your instinct to automate and deploy fast points toward cloud-native development. You enjoy infrastructure as much as code.",
            "skills": ["Azure", "Docker", "CI/CD", "Kubernetes"],
            "emoji": "☁️"
        }
    ]
    """;
        }
        //public async Task<string> AnalyzeAnswers(List<string> answers)
        //{
        //    var summary = string.Join("\n", answers.Select((a, i) => $"Q{i + 1}: {a}"));

        //    var prompt = $"""
        //        You are a tech career advisor. Based on these quiz answers, return the top 3 best-fit tech roles.

        //        {summary}

        //        Return ONLY a valid JSON array with exactly 3 objects, each with:
        //        - "role": job title
        //        - "match": percentage as integer
        //        - "why": 2 sentence explanation
        //        - "skills": array of 4 key skills
        //        - "emoji": a single relevant emoji
        //        """;

        //    var response = await _model.GenerateContent(prompt);
        //    return response.Text!;
        //}
    }
}