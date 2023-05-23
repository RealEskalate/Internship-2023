import 'package:intl/intl.dart';
import 'package:mobile_assessement/features/weatherify/domain/entity/weather_entity.dart';

class WeatherModel extends Weather {

  const WeatherModel({
    required super.cityName,
    required super.mintemperature,
    required super.maxtemperature,
    required super.next7DaysTemps,
    required super.date,
  }) : super();

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    List<dynamic> next7DaysData = json['data']['weather'][0]['hourly'].take(7).toList();
    List<String> next7DaysTemps = next7DaysData.map((data) => data['tempC'].toString()+'°C').toList();
    DateTime parsedDate = DateTime.parse(json['data']['weather'][0]['date']);
    String formattedDate = DateFormat('E, MMM d').format(parsedDate); // format the date using DateFormat
    return WeatherModel(
      cityName: json['data']['request'][0]['query'].toString(),
      mintemperature: json['data']['weather'][0]['mintempC'],
      maxtemperature: json['data']['weather'][0]['maxtempC'],
      next7DaysTemps: next7DaysTemps,
      date: formattedDate, // use the formatted date string
    );
  }
}