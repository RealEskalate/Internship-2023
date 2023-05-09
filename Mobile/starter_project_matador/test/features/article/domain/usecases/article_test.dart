import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:mockito/annotations.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/usecases/article_usecase.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

import 'article_test.mocks.dart';

@GenerateMocks([ArticleRepository])

void main() {
  late GetArticle usecase;
  late MockArticleRepository mockArticleRepository;

  setUp(() {
    mockArticleRepository = MockArticleRepository();
    usecase = GetArticle(mockArticleRepository);
  });

  const tArticleId = "1";
  final tArticle = Article(
      title: 'Test Article',
      subtitle: 'Test Subtitle',
      content: 'Test Content',
      date: DateTime.now(),
      likesCount: 5,
      tags: const ['Test', 'Article']);

  test(
    'should get article from the repository',
    () async {
      
      when(mockArticleRepository.getArticle(tArticleId))
          .thenAnswer((_) async => Right(tArticle));

      final result = await usecase( Params(articleId: tArticleId));
      
      expect(result, Right(tArticle));

      verify(mockArticleRepository.getArticle(tArticleId));

      verifyNoMoreInteractions(mockArticleRepository);
    },  
  );
}