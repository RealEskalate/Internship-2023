
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dark_knights/features/article/domain/usecases/post_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_articles_test.mocks.dart';

enum tags {
  Art, Music, 
}
@GenerateMocks([ArticleRepository])
void main(){
  late PostArticle usecase;
  late MockArticleRepository mockArticleRepository;

  setUp((){
    mockArticleRepository = MockArticleRepository();
    usecase = PostArticle(repository: mockArticleRepository);
  });

  Article article = Article(
    id: "article1", 
    title: "article 1", 
    subtitle: "subtitle one", 
    description: "description 2", 
    postedBy: "x", 
    publishedDate: DateTime(2017, 5, 3, 17, 30), 
    tag: tags.Art, 
    imageUrl: "imageUrl", 
    likeCount: 2, 
    timeEstimate: 1
  );
  test("should get the created article", ()async{
    when(mockArticleRepository.postArticle(article)).thenAnswer((_) async => Right(article));
    final result = await usecase(article);
    expect(result, Right(article));
    verify(mockArticleRepository.postArticle(article));
    verifyNoMoreInteractions(mockArticleRepository);
  });
}