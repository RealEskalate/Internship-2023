import '../../domain/entities/weather.dart';

class WeatherModel extends Weather {
  WeatherModel({
    required String minTemperature,
    required String maxTemperature,
    required String humidity,
    required String description,
  }) : super(
          description: description,
          maxTemperature: maxTemperature,
          minTemperature: minTemperature,
          humidity: humidity,
        );

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
        description: "hooot",
        maxTemperature: json['data']['weather'][0]['maxtempC'],
        minTemperature: json['data']['weather'][0]['mintempC'],
        humidity: json['data']['current_condition'][0]['humidity']);
  }

  Map<String, dynamic> toJson() {
    return {
      'minTemprature': minTemperature,
      'maxTemprature': minTemperature,
      'description': description,
      'humidity': humidity
    };
  }
}
