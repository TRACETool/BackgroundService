using Newtonsoft.Json;

namespace HistoricalDataService
{
    public class ProcessedCommit
    {
        [JsonProperty("RepositoryName")]
        public string RepositoryName { get; set; }

        [JsonProperty("Branch")]
        public string Branch { get; set; }

        [JsonProperty("Sha")]
        public string Sha { get; set; }

        [JsonProperty("AuthorName")]
        public string AuthorName { get; set; }

        [JsonProperty("AuthorEmail")]
        public string AuthorEmail { get; set; }

        [JsonProperty("CommitMessage")]
        public string CommitMessage { get; set; }

        [JsonProperty("Additions")]
        public int Additions { get; set; }

        [JsonProperty("Deletions")]
        public int Deletions { get; set; }

        [JsonProperty("TotalChanges")]
        public int TotalChanges { get; set; }

        [JsonProperty("FilesChanged")]
        public List<FilesChanged> FilesChanged { get; set; }

        [JsonProperty("SentimentScore")]
        public int SentimentScore { get; set; }

        [JsonProperty("CommitDate")]
        public DateTime CommitDate { get; set; }
    }

    public class FilesChanged
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("additions")]
        public int Additions { get; set; }

        [JsonProperty("deletions")]
        public int Deletions { get; set; }
    }

    public class HistoricalCommitDump
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("commits")]
        public List<ProcessedCommit> Commits { get; set; }
    }

}
