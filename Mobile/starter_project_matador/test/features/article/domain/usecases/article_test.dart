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
  late UpdateArticle usecase2;
  late DeleteArticle usecase3;
  late PostArticle usecase4;
  late MockArticleRepository mockArticleRepository;

  setUp(() {
    mockArticleRepository = MockArticleRepository();
    usecase = GetArticle(mockArticleRepository);
    usecase2 = UpdateArticle(mockArticleRepository);
    usecase3 = DeleteArticle(mockArticleRepository);
    usecase4 = PostArticle(mockArticleRepository);
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

      final result = await usecase(tArticleId);
      
      expect(result, Right(tArticle));

      verify(mockArticleRepository.getArticle(tArticleId));

      verifyNoMoreInteractions(mockArticleRepository);
    },  
  );

  test(
      'should update article in the repository',
      () async {
        when(mockArticleRepository.updateArticle(tArticle))
            .thenAnswer((_) async =>  Right(tArticle));

        final result = await usecase2(tArticle);

        expect(result, Right(tArticle));

        verify(mockArticleRepository.updateArticle(tArticle));

        verifyNoMoreInteractions(mockArticleRepository);
      },
    );

    test(
      'should delete article from the repository',
      () async {
        when(mockArticleRepository.deleteArticle(tArticleId))
            .thenAnswer((_) async => Right(tArticle));

        final result = await usecase3(tArticleId);

        expect(result, Right(tArticle));

        verify(mockArticleRepository.deleteArticle(tArticleId));

        verifyNoMoreInteractions(mockArticleRepository);
      },
    );

    test(
      'should post article to the repository',
      () async {
        when(mockArticleRepository.postArticle(tArticle))
            .thenAnswer((_) async => Right(tArticle));

        final result = await usecase4(tArticle);

        expect(result, Right(tArticle));

        verify(mockArticleRepository.postArticle(tArticle));

        verifyNoMoreInteractions(mockArticleRepository);
      },
    );
  }