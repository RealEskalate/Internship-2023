import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

class MockArticleRepository extends Mock implements ArticleRepository {
  @override
  Future<Either<Failure, Article>> postArticle(Article article) async {

    return Right(article);
  }
}
