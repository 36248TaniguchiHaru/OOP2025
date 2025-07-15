using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var employees = Deserialize("employees.json");
            ToXmlFile(employees);
        }

        static Employee[] Deserialize(string filePath) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals |
                                 JsonNumberHandling.AllowReadingFromString
            };
            var text = File.ReadAllText(filePath);
            var employees = JsonSerializer.Deserialize<Employee[]>(text,options);
            return employees ?? [];
        }

        static void ToXmlFile(Employee[] employees) {
            XmlRootAttribute xRoot = new XmlRootAttribute {
                ElementName = "Employee"
            };
            using (var writer = XmlWriter.Create("employee.xml")) {
                var serializer = new XmlSerializer(employees.GetType(),xRoot);
                serializer.Serialize(writer, employees);
            }
        }
    }

    public record Employee {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("hireDate")]
        public DateTime HireDate { get; set; }
    }
}
