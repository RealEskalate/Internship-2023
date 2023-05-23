class WeatherModel {
  final String city;
  final double temperature;
  final double humidity;
  final String description;

  WeatherModel({
    required this.city,
    required this.temperature,
    required this.humidity,
    required this.description,
  });

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      temperature: json['temperature'],
      humidity: json['humidity'],
      description: json['description'],
      city: json['city']
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'temperature': temperature,
      'humidity': humidity,
      'description': description,
    };
  }
}
