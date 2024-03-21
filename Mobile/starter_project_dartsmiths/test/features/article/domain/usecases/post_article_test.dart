
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartsmiths/features/article/domain/usecases/post_article.dart';
import 'package:dartsmiths/features/article/domain/usecases/update_article.dart';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:mockito/annotations.dart';

import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'post_article_test.mocks.dart';

@GenerateMocks([ArticleRepository])


void main() {

  late PostArticle usecase;
  late MockArticleRepository mockArticleRepository;


  setUp(() {
    mockArticleRepository = MockArticleRepository();
    usecase = PostArticle(mockArticleRepository);

  } );

  final Article tArticle = Article(id: "1234qwer", title: "Sport", subTitle: "Athletics", content: "Ethiopian althlets are ready for the coming olympic", tags: ["athlets", "olympic"], authorId: "ididid");

  test("should post article to the repository", () async{
    
    // arrange
    when(mockArticleRepository.postArticle(tArticle)).thenAnswer((_) async => Right(tArticle));

    // act
    final result = await usecase(tArticle);

    // assert
    expect(result, Right(tArticle));
    verify(mockArticleRepository.postArticle(tArticle));
    verifyNoMoreInteractions(mockArticleRepository);

  });

  test('should return a failure when posting article fails', () async {
    // arrange
    when( mockArticleRepository.postArticle(tArticle)).thenAnswer((_) async => Left(ServerFailure()));
    // act
    final result = await usecase(tArticle);
    // assert
    expect(result, Left(ServerFailure()));
    verify(mockArticleRepository.postArticle(tArticle));
    verifyNoMoreInteractions(mockArticleRepository);
  });
  
}