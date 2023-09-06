Test description:
StudentConverterTests contains unit tests conering  StudentConverter class ConvertStudents() method with positive and negative cases, positive cases:
High Achiever and Exceptional Young High Achiever detemination, grades check if student passed or failed, negative cases: if bad input for empty array returns empty array, for null returns ArgumentNullexception

PlayerAnalyzerTests contains unit tests conering  PlayerAnalyzer class CalculateScore() method with positive and negative cases. Positive cases:
PlayerAnalyzer should correctly calculate score for multiple cases, Junior, Normal and Senior Players, whne multiple player provided score should be a sum of all players scores,
negative cases: if provided player without skills property should throw ArgumentNullException, for empty players array should return 0;

To run tests locally execute "dotnet test" command in terminal, or use VisualStudio test explorer feature