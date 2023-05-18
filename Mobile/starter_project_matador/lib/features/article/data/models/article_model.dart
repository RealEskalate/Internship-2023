import 'package:matador/features/article/domain/entities/article.dart';

class ArticleModel extends Article {


  ArticleModel({
    required String id,
    required String title,
    required String subtitle,
    required String content,
    required DateTime date,
    required int likesCount,
    required List<String> tags,
  }) : super(
          id: id,
          title: title,
          subtitle: subtitle,
          content: content,
          date: date,
          likesCount: likesCount,
          tags: tags,
        );

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    return ArticleModel(
      id: json['id'],
      title: json['title'],
      subtitle: json['subtitle'],
      content: json['content'],
      date: DateTime.parse(json['date']),
      likesCount: json['likesCount'],
      tags: List<String>.from(json['tags']),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'subtitle': subtitle,
      'content': content,
      'date': date.toIso8601String(),
      'likesCount': likesCount,
      'tags': tags,
    };
  }
}