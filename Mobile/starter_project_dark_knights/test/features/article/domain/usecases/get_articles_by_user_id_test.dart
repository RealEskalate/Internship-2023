
import 'dart:math';

import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dark_knights/features/article/domain/usecases/get_articles_by_user_id.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'get_articles_test.mocks.dart';


@GenerateMocks([ArticleRepository])
void main(){
  late GetArticlesByUserId usecase;
  late MockArticleRepository mockArticleRepository;

  setUp((){
    mockArticleRepository = MockArticleRepository();
    usecase = GetArticlesByUserId(repository: mockArticleRepository);
  });

  List<Article> articles = [Article(id: "id", title: "title", subtitle: "subtitle", description: "description", postedBy: "x", publishedDate: DateTime(2023, 5, 10, 11,24), tag: "Music", imageUrl: "imageUrl", likeCount: 2, timeEstimate: 6),
                   Article(id: "id", title: "title", subtitle: "subtitle", description: "description", postedBy: "x", publishedDate: DateTime(2023, 4, 3, 6, 30,3), tag: "Art", imageUrl: "imageUrl", likeCount: 2, timeEstimate: 1)];
  const userId = "x";
  test('should get list of articles by the given user id', () async {
    when(mockArticleRepository.getArticlesByUserId("x")).thenAnswer((_) async =>  Right(articles));

    final result = await usecase(userId);
    expect(result, Right(articles));
    verify(mockArticleRepository.getArticlesByUserId(userId));
    verifyNoMoreInteractions(mockArticleRepository);
  });
}