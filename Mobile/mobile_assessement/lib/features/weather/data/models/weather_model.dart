import '../../domain/entities/weather.dart';

class WeatherModel extends Weather {
  WeatherModel({
    required String minTemperature,
    required String averageTemp,
    required String maxTemperature,
    required String humidity,
    required String description,
  }) : super(
          description: description,
          maxTemperature: maxTemperature,
          minTemperature: minTemperature,
          humidity: humidity,
          averageTemp: averageTemp,
        );

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
        description: "hooot",
        maxTemperature: json['data']['weather'][0]['maxtempC'],
        minTemperature: json['data']['weather'][0]['mintempC'],
        humidity: json['data']['current_condition'][0]['humidity'],
        averageTemp: json['data']['current_condition'][0]['temp_C']);
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
