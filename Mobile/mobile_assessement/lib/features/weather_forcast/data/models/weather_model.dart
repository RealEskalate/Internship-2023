import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather.dart';

class WeatherModel extends Weather {
  const WeatherModel({
    required String condition,
    required String conditionIcon,
    required double temperature,
    required double highTemperature,
    required double lowTemperature,
    required double windSpeed,
    required int humidity,
    required DateTime date,
  }) : super(
            condition: condition,
            conditionIcon: conditionIcon,
            temperature: temperature,
            highTemperature: highTemperature,
            lowTemperature: lowTemperature,
            windSpeed: windSpeed,
            humidity: humidity,
            date: date);

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      condition: json['weather'][0]['main'],
      conditionIcon: json['weather'][0]['icon'],
      temperature: (json['main']['temp'] as num).toDouble(),
      highTemperature: (json['main']['temp_max'] as num).toDouble(),
      lowTemperature: (json['main']['temp_min'] as num).toDouble(),
      windSpeed: (json['wind']['speed'] as num).toDouble(),
      humidity: json['main']['humidity'],
      date: DateTime.fromMillisecondsSinceEpoch(json['dt'] * 1000),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'weather': [
        {'main': condition, 'icon': conditionIcon}
      ],
      'main': {
        'temp': temperature,
        'temp_max': highTemperature,
        'temp_min': lowTemperature,
        'humidity': humidity
      },
      'wind': {'speed': windSpeed},
      'dt': date.millisecondsSinceEpoch ~/ 1000
    };
  }
}
