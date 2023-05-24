import '../../domain/entities/city_entity.dart';
import 'weather_model.dart';

class CityModel extends City {
  CityModel({required String name, required List<WeatherModel> weathers})
      : super(name: name, weathers: weathers);

  factory CityModel.fromJson(Map<String, dynamic> json) {
    return CityModel(
      name: json['data']['request'][0]['query'],
      weathers: (json['data']['weather'] as List)
          .map((weather) => WeatherModel.fromJson(weather))
          .toList(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'data': {
        'request': [
          {'query': name}
        ],
        'weather': weathers
            .map((weather) => (weather as WeatherModel).toJson())
            .toList(),
      }
    };
  }
}
