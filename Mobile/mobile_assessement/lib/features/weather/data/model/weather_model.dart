class WeatherModel {
  final String city;
  final String temperature;
  final String humidity;
  final String description;

  WeatherModel({
    required this.city,
    required this.temperature,
    required this.humidity,
    required this.description,
  });

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
        temperature: json['current_condition'][0]['temp_C'],
        humidity: json['current_condition'][0]['humidity'],
        description: json['current_condition'][0]['weatherDesc'][0]['value'],
        city: json['request'][0]['query']);
  }

  Map<String, dynamic> toJson() {
    return {
      'temperature': temperature,
      'humidity': humidity,
      'description': description,
      'city': city
    };
  }
}
