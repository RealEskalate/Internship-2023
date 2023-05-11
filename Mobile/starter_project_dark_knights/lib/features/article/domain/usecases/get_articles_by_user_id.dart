
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticlesByUserId {
  final ArticleRepository repository;
  GetArticlesByUserId({required this.repository});


  Future<Either<Failure, List<Article>>> call( String userId) async {
    return await repository.getArticlesByUserId(userId);
  }
}
