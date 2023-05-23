import 'package:flutter/foundation.dart';
import 'package:meta/meta.dart';

import '../../domain/entities/weather.dart';

class WeatherModel extends Weather {
  WeatherModel(
      {required String city,
      required double temprature,
      required String description,
      required String favKey})
      : super(
        city: city,
        temprature: temprature,
        description: description,
        favKey: favKey
      );

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      city: json['city'],
        temprature: json['temprature'],
        description: json['description'],
        favKey: json['favKey'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'city': city,
      'temprature': temprature,
      'description': description,
      'favKey': favKey
    };
  }
}
