import '../models/article_model.dart';

abstract class ArticleLocalDataSource {
  Future<ArticleModel> getArticle(String articleId);
}

