namespace CleanArchitecture.Persistance.SqlServer.Entities {
    using System;
    using System.Collections.Generic;

    public class Article {
        private List<ArticleUnit> units = new();

        private Article() {
        }

        public int Id { get; private set; } = 0;

        public string Code { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public string Unit { get; private set; } = string.Empty;

        public IReadOnlyCollection<ArticleUnit> Units => units;

        public void AddUnit(string unit) {
            units.Add(new ArticleUnit(unit));
        }

        public static Article Create(string code, string name, string unit) {
            if (string.IsNullOrWhiteSpace(code)) {
                throw new System.ArgumentException($"'{nameof(code)}' cannot be null or whitespace.", nameof(code));
            }

            if (string.IsNullOrWhiteSpace(name)) {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(unit)) {
                throw new System.ArgumentException($"'{nameof(unit)}' cannot be null or whitespace.", nameof(unit));
            }

            return new Article {
                Code = code,
                Name = name,
                Unit = unit
            };
        }
    }

    public class ArticleUnit {
        public ArticleUnit(string unit) {
            if (string.IsNullOrWhiteSpace(unit)) {
                throw new System.ArgumentException($"'{nameof(unit)}' cannot be null or whitespace.", nameof(unit));
            }

            Unit = unit;
        }

        public string Unit { get; }
    }
}
