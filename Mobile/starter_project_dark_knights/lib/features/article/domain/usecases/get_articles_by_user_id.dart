
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticlesByUserId {
  final ArticleRepository repository;
  GetArticlesByUserId({required this.repository});


  Future<Either<Failure, List<Article>>> call(Params params) async {
    return await repository.getArticlesByUserId(params.userId);
  }
}

class Params extends Equatable{
  final String userId;
  const Params({required this.userId});

  @override
  List<Object> get props => [userId];
}