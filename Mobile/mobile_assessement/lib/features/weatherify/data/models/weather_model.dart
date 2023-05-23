import 'package:mobile_assessement/features/weatherify/domain/entities/weather.dart';

class WeatherModel extends Weather {
  final String cityName;
  final String date;
  final String weatherDesc;
  final String image;
  final String temperature;

  WeatherModel(
      {required this.temperature,
      required this.cityName,
      required this.date,
      required this.weatherDesc,
      required this.image})
      : super(
            temperature: '',
            cityName: '',
            date: '',
            weatherDesc: '',
            image: '');

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      cityName: json["cityName"],
      date: json["date"],
      image: json["image"],
      temperature: json["temperature"],
      weatherDesc: json["weatherDesc"],
    );
  }

  // Convert the model to JSON
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data["cityName"] = cityName;
    data["date"] = date;
    data["image"] = image;
    data["temperature"] = temperature;
    data["weatherDesc"] = weatherDesc;
    return data;
  }
}
