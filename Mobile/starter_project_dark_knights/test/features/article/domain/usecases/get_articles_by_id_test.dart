import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dark_knights/features/article/domain/usecases/get_article_by_id.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_articles_test.mocks.dart';

@GenerateMocks([ArticleRepository])
enum tags {
  news, sports, movies
}
void main(){

  setUp(() {
    final mockArticleRepository = MockArticleRepository();
    final usecase = GetArticleById(repository: mockArticleRepository);
  });
  
  final Article articles = Article(id: 'article1', title: "New Article", subtitle: "new article", description: "this is new article", postedBy: "alex", publishedDate: DateTime(2022, 9, 7, 19), tag: tags.movies, imageUrl: 'imageUrl', likeCount: 2, timeEstimate: 3,);

  test ('should get single article detail', ()async {
    final mockArticleRepository = MockArticleRepository();
    final usecase = GetArticleById(repository: mockArticleRepository);
    when(mockArticleRepository.getArticleById('article1')).thenAnswer((_) async => Right(articles));

    final result = await usecase(const Params(id: 'article1'));

    expect(result, Right(articles));
    verify(mockArticleRepository.getArticleById('article1'));
    verifyNoMoreInteractions(mockArticleRepository);
  });
}