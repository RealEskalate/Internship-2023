import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:flutter/foundation.dart';
import 'package:meta/meta.dart';

class ArticleModel extends Article {
  
  ArticleModel(
      {required String id,
      required String title,
      required String subTitle,
      required String content,
      required List<String> tags,
      required String authorId})
      : super(
            id: id,
            authorId: authorId,
            tags: tags,
            title: title,
            subTitle: subTitle,
            content: content);

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    return ArticleModel(
      id: json['id'],
      title: json['title'],
      subTitle: json['subTitle'],
      content: json['content'],
      tags: List<String>.from(json['tags']),
      authorId: json['authorId'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'subTitle': subTitle,
      'content': content,
      'tags': tags,
      'authorId': authorId
    };
  }
}
