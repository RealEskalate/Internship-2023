import '../models/article_model.dart';

abstract class ArticleLocalDataSource {
  Future<ArticleModel> getArticle(String articleId);
}

class ArticleLocalDataSourceImpl implements ArticleLocalDataSource {
  @override
  Future<ArticleModel> getArticle(String articleId) {
    // TODO: Implement local data source methods
    throw UnimplementedError();
  }
}