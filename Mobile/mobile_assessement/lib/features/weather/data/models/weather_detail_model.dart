import 'package:mobile_assessement/features/weather/data/models/weather_detail_model.dart';

import '../../domain/entities/weather_detail_domain.dart';

class TemperatureDataModel{
  String city;
  List<TemperatureDataDetailModel> temperatureDataDetailModel;
  String iconUrl;

  TemperatureDataModel(
      {required this.city,
      required this.temperatureDataDetailModel, required this.iconUrl});

            // _CastError (type 'Right<dynamic, TemperatureDataModel>' is not a subtype of type 'TemperatureDataModel' in type cast)



  factory TemperatureDataModel.fromJson(Map<String, dynamic> json) {
    List<dynamic> temperatureDataDetailnew = json['weather'];
  

    List<TemperatureDataDetailModel> weathers = temperatureDataDetailnew
        .map((weather) => TemperatureDataDetailModel.fromJson(weather))
        .toList();

    return TemperatureDataModel(
        city: json['request'][0]['query'], 
        temperatureDataDetailModel: weathers,
         iconUrl: json['current_condition'][0]['weatherIconUrl'][0]['value'],
         
        );
  }
}

class TemperatureDataDetailModel  {
  DateTime date;
  String minTemp;
  String maxTemp;
  String humidity;
  String avgTemp;
  String weatherDescription;
  String iconUrl;

  TemperatureDataDetailModel(
      {required this.weatherDescription,
      required this.date,
      required this.minTemp,
      required this.maxTemp,
      required this.humidity,
      required this.avgTemp,
      required this.iconUrl
      });

  factory TemperatureDataDetailModel.fromJson(Map<String, dynamic> json) {
    return TemperatureDataDetailModel(
      iconUrl: json['hourly'][0]['weatherIconUrl'][0]['value'],
        date: DateTime.parse(json['date']) ,
        minTemp: json['mintempC'] ?? "",
        maxTemp: json['maxtempC'] ?? "",
        humidity: json['hourly'][0]['humidity'] ?? "",
        avgTemp: json['avgtempC'] ?? "",
        weatherDescription: json['hourly'][0]['weatherDesc'][0]['value']);
  }
}
