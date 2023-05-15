import '../../domain/entity/home.dart';

class HomeModel extends Home {
  const HomeModel({
    required super.author,
    required super.title,
    required super.description,
    required super.tag,
    super.imageUrl,
    super.dateTime,
  });
  factory HomeModel.fromJson(Map<String, dynamic> json) {
    return HomeModel(
      author: json['author'],
      title: json['title'],
      description: json['description'],
      tag: json['tag'],
      imageUrl: json['imageUrl'],
      dateTime: json['dateTime'],
    );
  }
  Map<String, dynamic> toJson() {
    return {
      'author': author,
      "title": title,
      "description": description,
      "tag": tag,
      "imageUrl": imageUrl,
      "dateTime": dateTime
    };
  }
}