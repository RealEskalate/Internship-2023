import '../../domain/entity/home.dart';

class HomeModel extends Home {
  const HomeModel({
    required super.city,
    required super.country,
    required super.temperature,
    
  });
  factory HomeModel.fromJson(Map<String, dynamic> json) {
    return HomeModel(
      city: json['city'],
      country: json['country'],
      temperature: json['temperature'],
     
    );
  }
  Map<String, dynamic> toJson() {
    return {
      "city": city,
      "country": country,
      "temperature": temperature,
      
    };
  }
}