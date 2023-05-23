import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:meta/meta.dart';
import 'package:mobile_assessement/core/error/exception.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_detail_model.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_weather_detail.dart';


abstract class WeatherRemoteDataSource {
  Future<TemperatureDataModel> GetWeather(String city);
}

class WeatherRemoteDataSourceImp extends WeatherRemoteDataSource {
  final http.Client client;
  WeatherRemoteDataSourceImp({required this.client});


  @override
  Future<TemperatureDataModel> GetWeather(String city) async {

    try {

      print("\n\n\n\n\n\n\n\n\n\n\n\n");
      print("respofwasfaewwsfoiuwqehsfoiwlahfpiwhf\n\n\n\n\n\nn/n/n/n/n/n/n\n\n\n\n\nse");
    
      print("\n\n\n\n\n\n\n\n\n\n\n\n");

      var response = await client.get(Uri.parse("https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=7d197f528a0548e085e123715232205&q=London&format=JSON"));
      print("\n\n\n\n\n\n\n\n\n\n\n\n");
      print(response.body + "Sda");



      var decodedResponse =
          jsonDecode(utf8.decode(response.bodyBytes)) as Map<String, dynamic>;
      print("\n\n\n\n\n\n\n\n\n\n\n\n");
      print(decodedResponse['data']);
      return TemperatureDataModel.fromJson(decodedResponse['data']);


    } on Exception catch (e) {
      throw ServerException();
      
    }
  }
  
}

