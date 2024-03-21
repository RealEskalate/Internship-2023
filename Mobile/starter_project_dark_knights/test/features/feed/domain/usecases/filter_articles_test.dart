import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/feeds/domain/repositories/feed_repository.dart';
import 'package:dark_knights/features/feeds/domain/usecases/filter_articles.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_articles_test.mocks.dart';

@GenerateMocks([FeedRepository])
void main() {
  late FilterArticles usecase;
  late MockFeedRepository mockFeedRepository;

  setUp(() {
    mockFeedRepository = MockFeedRepository();
    usecase = FilterArticles(repository: mockFeedRepository);
  });

  final List<Article> articles = [
    Article(
      id: 'article1',
      title: "New Article",
      subtitle: "new article",
      description: "this is new article",
      postedBy: "alex",
      publishedDate: DateTime(2022, 9, 7, 19),
      tag: "movies",
      imageUrl: 'imageUrl',
      likeCount: 2,
      timeEstimate: 3,
    ),
  ];

  const String tTag = "movies";
  test('should get list of articles', () async {
    when(mockFeedRepository.filterArticles(tTag))
        .thenAnswer((_) async => Right(articles));
    final result = await usecase(tTag);

    expect(result, Right(articles));
    verify(mockFeedRepository.filterArticles(tTag));
    verifyNoMoreInteractions(mockFeedRepository);
  });

  test('should return Server Failure when not getting list of articles',
      () async {
    when(mockFeedRepository.filterArticles(tTag))
        .thenAnswer((_) async => Left(ServerFailure("Server Failure")));
    final result = await usecase(tTag);

    expect(result, Left(ServerFailure("Server Failure")));
    verify(mockFeedRepository.filterArticles(tTag));
    verifyNoMoreInteractions(mockFeedRepository);
  });
}
