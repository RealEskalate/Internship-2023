import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dark_knights/features/article/domain/usecases/update_articles.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_articles_test.mocks.dart';



@GenerateMocks([ArticleRepository])
void main(){
  late UpdateArticle usecase;
  late MockArticleRepository mockArticleRepository;
  setUp((){
    mockArticleRepository = MockArticleRepository();
    usecase = UpdateArticle(repository: mockArticleRepository);
  });

  Article article = Article(id: "1", title: "Article 1", subtitle: "article", description: "description", postedBy: "x", publishedDate: DateTime(2023, 5, 10, 15, 27), tag: "Philosophy", imageUrl: "img/", likeCount: 2, timeEstimate: 4);
  String id = "1";
  test("should get the updated article", ()async {
    when(mockArticleRepository.updateArticle(id, article)).thenAnswer((_) async => Right(article));
    final result = await usecase(id, article);
    expect(result, Right(article));
    verify(mockArticleRepository.updateArticle(id, article));
    verifyNoMoreInteractions(mockArticleRepository);
  });
}