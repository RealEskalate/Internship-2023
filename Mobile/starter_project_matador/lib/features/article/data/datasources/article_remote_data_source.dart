import '../models/article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> getArticle(String articleId);
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  @override
  Future<ArticleModel> getArticle(String articleId) {
    // TODO: Implement remote data source methods
    throw UnimplementedError();
  }
}