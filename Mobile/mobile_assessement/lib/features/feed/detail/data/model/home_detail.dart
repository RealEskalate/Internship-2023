import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';

class HomeDetailModel extends HomeDetail {
  const HomeDetailModel(
      {required super.city,
      required super.temperature,
      required super.description,
      required super.date});

  factory HomeDetailModel.fromJson(Map<String, dynamic> json) {
    return HomeDetailModel(
      city: json['city'],
      description: json['description'],
      date:json['date'],
      temperature: json['temperature'],
    );
  }
  Map<String, dynamic> toJson() {
    return {
      "city": city,
      "temperature": temperature,
      "description":description,
      "date":date

    };
  }
}
