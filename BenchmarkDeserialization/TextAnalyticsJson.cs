using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDeserialization
{
    public class TextAnalyticsJson
    {
        public static string SentimentResponse = @"{
  ""documents"": [
    {
      ""confidenceScores"": {
        ""negative"": 0,
        ""neutral"": 0,
        ""positive"": 1
      },
      ""id"": ""1"",
      ""sentences"": [
        {
          ""targets"": [
            {
              ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
              },
              ""length"": 10,
              ""offset"": 6,
              ""relations"": [
                {
                  ""ref"": ""#/documents/0/sentences/0/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""atmosphere""
            }
          ],
          ""confidenceScores"": {
    ""negative"": 0,
            ""neutral"": 0,
            ""positive"": 1
          },
          ""length"": 17,
          ""offset"": 0,
          ""assessments"": [
            {
              ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
              },
              ""isNegated"": false,
              ""length"": 5,
              ""offset"": 0,
              ""sentiment"": ""positive"",
              ""text"": ""great""
            }
          ],
          ""sentiment"": ""positive"",
          ""text"": ""Great atmosphere.""
        },
        {
    ""targets"": [
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""length"": 11,
              ""offset"": 37,
              ""relations"": [
                {
            ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""restaurants""
            },
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""length"": 6,
              ""offset"": 50,
              ""relations"": [
                {
            ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""hotels""
            }
          ],
          ""confidenceScores"": {
        ""negative"": 0.01,
            ""neutral"": 0.86,
            ""positive"": 0.13
          },
          ""length"": 52,
          ""offset"": 18,
          ""assessments"": [
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""isNegated"": false,
              ""length"": 15,
              ""offset"": 18,
              ""sentiment"": ""positive"",
              ""text"": ""Close to plenty""
            }
          ],
          ""sentiment"": ""neutral"",
          ""text"": ""Close to plenty of restaurants, hotels, and transit!""
        }
      ],
      ""sentiment"": ""positive"",
      ""warnings"": []
    },
    {
    ""confidenceScores"": {
        ""negative"": 0,
          ""neutral"": 0,
          ""positive"": 1
        },
        ""id"": ""1"",
        ""sentences"": [
          {
        ""targets"": [
              {
            ""confidenceScores"": {
                ""negative"": 0,
                  ""positive"": 1
                },
                ""length"": 10,
                ""offset"": 6,
                ""relations"": [
                  {
                ""ref"": ""#/documents/0/sentences/0/assessments/0"",
                    ""relationType"": ""assessment""
                  }
                ],
                ""sentiment"": ""positive"",
                ""text"": ""atmosphere""
              }
            ],
            ""confidenceScores"": {
            ""negative"": 0,
              ""neutral"": 0,
              ""positive"": 1
            },
            ""length"": 17,
            ""offset"": 0,
            ""assessments"": [
              {
            ""confidenceScores"": {
                ""negative"": 0,
                  ""positive"": 1
                },
                ""isNegated"": false,
                ""length"": 5,
                ""offset"": 0,
                ""sentiment"": ""positive"",
                ""text"": ""great""
              }
            ],
            ""sentiment"": ""positive"",
            ""text"": ""Great atmosphere.""
          },
          {
        ""targets"": [
              {
            ""confidenceScores"": {
                ""negative"": 0.01,
                  ""positive"": 0.99
                },
                ""length"": 11,
                ""offset"": 37,
                ""relations"": [
                  {
                ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                    ""relationType"": ""assessment""
                  }
                ],
                ""sentiment"": ""positive"",
                ""text"": ""restaurants""
              },
              {
            ""confidenceScores"": {
                ""negative"": 0.01,
                  ""positive"": 0.99
                },
                ""length"": 6,
                ""offset"": 50,
                ""relations"": [
                  {
                ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                    ""relationType"": ""assessment""
                  }
                ],
                ""sentiment"": ""positive"",
                ""text"": ""hotels""
              }
            ],
            ""confidenceScores"": {
            ""negative"": 0.01,
              ""neutral"": 0.86,
              ""positive"": 0.13
            },
            ""length"": 52,
            ""offset"": 18,
            ""assessments"": [
              {
            ""confidenceScores"": {
                ""negative"": 0.01,
                  ""positive"": 0.99
                },
                ""isNegated"": false,
                ""length"": 15,
                ""offset"": 18,
                ""sentiment"": ""positive"",
                ""text"": ""Close to plenty""
              }
            ],
            ""sentiment"": ""neutral"",
            ""text"": ""Close to plenty of restaurants, hotels, and transit!""
          }
        ],
        ""sentiment"": ""positive"",
        ""warnings"": []
    },
    {
    ""confidenceScores"": {
        ""negative"": 0,
        ""neutral"": 0,
        ""positive"": 1
    },
    ""id"": ""1"",
    ""sentences"": [
        {
        ""targets"": [
            {
            ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
            },
            ""length"": 10,
            ""offset"": 6,
            ""relations"": [
                {
                ""ref"": ""#/documents/0/sentences/0/assessments/0"",
                ""relationType"": ""assessment""
                }
            ],
            ""sentiment"": ""positive"",
            ""text"": ""atmosphere""
            }
        ],
        ""confidenceScores"": {
            ""negative"": 0,
            ""neutral"": 0,
            ""positive"": 1
        },
        ""length"": 17,
        ""offset"": 0,
        ""assessments"": [
            {
            ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
            },
            ""isNegated"": false,
            ""length"": 5,
            ""offset"": 0,
            ""sentiment"": ""positive"",
            ""text"": ""great""
            }
        ],
        ""sentiment"": ""positive"",
        ""text"": ""Great atmosphere.""
        },
        {
        ""targets"": [
            {
            ""confidenceScores"": {
                ""negative"": 0.01,
                ""positive"": 0.99
            },
            ""length"": 11,
            ""offset"": 37,
            ""relations"": [
                {
                ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                ""relationType"": ""assessment""
                }
            ],
            ""sentiment"": ""positive"",
            ""text"": ""restaurants""
            },
            {
            ""confidenceScores"": {
                ""negative"": 0.01,
                ""positive"": 0.99
            },
            ""length"": 6,
            ""offset"": 50,
            ""relations"": [
                {
                ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                ""relationType"": ""assessment""
                }
            ],
            ""sentiment"": ""positive"",
            ""text"": ""hotels""
            }
        ],
        ""confidenceScores"": {
            ""negative"": 0.01,
            ""neutral"": 0.86,
            ""positive"": 0.13
        },
        ""length"": 52,
        ""offset"": 18,
        ""assessments"": [
            {
            ""confidenceScores"": {
                ""negative"": 0.01,
                ""positive"": 0.99
            },
            ""isNegated"": false,
            ""length"": 15,
            ""offset"": 18,
            ""sentiment"": ""positive"",
            ""text"": ""Close to plenty""
            }
        ],
        ""sentiment"": ""neutral"",
        ""text"": ""Close to plenty of restaurants, hotels, and transit!""
        }
    ],
    ""sentiment"": ""positive"",
    ""warnings"": []
    }
  ],
  ""errors"": [],
  ""modelVersion"": ""2020-04-01""
}";
    }
}
