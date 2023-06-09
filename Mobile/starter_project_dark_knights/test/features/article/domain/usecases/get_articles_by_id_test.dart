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

void main(){
  late MockArticleRepository mockArticleRepository;
  late GetArticleById usecase;
  setUp(() {
    mockArticleRepository = MockArticleRepository();
    usecase = GetArticleById(repository: mockArticleRepository);
  });
  
  final Article article = Article(id: 'article1', title: "New Article", subtitle: "new article", description: "this is new article", postedBy: "alex", publishedDate: DateTime(2022, 9, 7, 19), tag: "Movies", imageUrl: 'imageUrl', likeCount: 2, timeEstimate: 3,);
  const String id = "article1";
  test ('should get single article detail', ()async {
    when(mockArticleRepository.getArticleById(id)).thenAnswer((_) async => Right(article));

    final result = await usecase(id);

    expect(result, Right(article));
    verify(mockArticleRepository.getArticleById(id));
    verifyNoMoreInteractions(mockArticleRepository);
  });
}