import 'package:matador/features/article/domain/entities/article.dart';

class ArticleModel extends Article {
  ArticleModel({
    required String title,
    required String subtitle,
    required String content,
    required DateTime date,
    required int likesCount,
    required List<String> tags,
  }) : super(
          title: title,
          subtitle: subtitle,
          content: content,
          date: date,
          likesCount: likesCount,
          tags: tags,
        );
}