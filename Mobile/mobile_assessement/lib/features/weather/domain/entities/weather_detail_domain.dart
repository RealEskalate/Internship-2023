


import 'package:equatable/equatable.dart';

class TemperatureData extends Equatable {
  final String city;
  final  String iconUrl;
  List<TemperatureDataDetail> temperatureDataDetail;

  TemperatureData({required this.iconUrl, required this.city, required this.temperatureDataDetail});
  
  @override
  List<Object?> get props => [city, temperatureDataDetail, iconUrl];
}


class TemperatureDataDetail {
  DateTime date;
  String minTemp;
  String maxTemp;
  String humidity;
  String avgTemp;
  String weatherDescription;
  String iconUrl;
  TemperatureDataDetail({ required this.iconUrl, required this.weatherDescription, required this.date, required this.minTemp, required this.maxTemp, required this.humidity, required this.avgTemp});
}


