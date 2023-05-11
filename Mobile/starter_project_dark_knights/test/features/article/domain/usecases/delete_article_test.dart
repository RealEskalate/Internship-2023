

import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dark_knights/features/article/domain/usecases/delete_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_articles_test.mocks.dart';

enum tags {
  Sports, Art, 
}
@GenerateMocks([ArticleRepository])
void main(){
  late DeleteArticle usecase;
  late MockArticleRepository mockArticleRepository;
  
  setUp((){
    mockArticleRepository = MockArticleRepository();
    usecase = DeleteArticle(repository: mockArticleRepository);
  });
    Article article = Article(id: 'article1', title: "Article", subtitle: "article", description: "description of article", postedBy: "user", publishedDate: DateTime(2023, 5, 10, 17, 30), tag: tags.Art, imageUrl: 'https://..', likeCount: 2, timeEstimate: 2);
    String id = "article1";
    test("should delete article with the given id", () async{
      when(mockArticleRepository.deleteArticle(id)).thenAnswer((_) async => Right(article));
      final result = await usecase(Params(id:id));
      expect(result, Right(article));
      verify(mockArticleRepository.deleteArticle(id));
      verifyNoMoreInteractions(mockArticleRepository);
    });

  }
