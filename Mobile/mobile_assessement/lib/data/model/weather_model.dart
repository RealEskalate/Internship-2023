class WeatherModel {
  final String city;
  final double temperature;
  final DateTime dateTime;

  WeatherModel({
    required this.city,
    required this.temperature,
    required this.dateTime,
  });

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      city: json['city'],
      temperature: json['temperature'].toDouble(),
      dateTime: DateTime.parse(json['dateTime']),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'city': city,
      'temperature': temperature,
      'dateTime': dateTime.toIso8601String(),
    };
  }
}
