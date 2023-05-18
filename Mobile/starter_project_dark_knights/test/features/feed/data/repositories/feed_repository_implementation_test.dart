import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:dark_knights/features/feeds/data/datasources/feed_remote_data_source.dart';
import 'package:dark_knights/features/feeds/data/repositories/feed_repository_implementation.dart';
import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:mockito/annotations.dart';

import 'feed_repository_implementation_test.mocks.dart';

@GenerateMocks([FeedRemoteDataSource])
void main() {
  late FeedRepositoryImplementation repository;
  late MockFeedRemoteDataSource mockRemoteDataSource;

  setUp(() {
    mockRemoteDataSource = MockFeedRemoteDataSource();
    repository = FeedRepositoryImplementation(
      remoteDataSource: mockRemoteDataSource,
    );
  });

  final tArticles = [
    ArticleModel(
      id: 'article1',
      title: "Article",
      subtitle: "article",
      description: "description of article",
      postedBy: "user",
      publishedDate: DateTime(2023, 5, 10, 17, 30),
      tag: "art",
      imageUrl: 'https://..',
      likeCount: 2,
      timeEstimate: 2,
    )
  ];

  group('getArticles', () {
    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockRemoteDataSource.getArticles())
            .thenAnswer((_) async => tArticles);
        // act
        final result = await repository.getArticles();
        // assert
        verify(mockRemoteDataSource.getArticles());
        expect(result, equals(Right(tArticles)));
      },
    );

    test(
      'should return server failure when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockRemoteDataSource.getArticles())
            .thenThrow(ServerException("Internal Server Failure!"));
        // act
        final result = await repository.getArticles();
        // assert
        verify(mockRemoteDataSource.getArticles());
        expect(result, equals(Left(ServerFailure("Internal Server Failure!"))));
      },
    );
  });

  group('filterArticles', () {
    const String tTag = "test";
    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockRemoteDataSource.filterArticles(tTag))
            .thenAnswer((_) async => tArticles);
        // act
        final result = await repository.filterArticles(tTag);
        // assert
        verify(mockRemoteDataSource.filterArticles(tTag));
        expect(result, equals(Right(tArticles)));
      },
    );

    test(
      'should return server failure when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockRemoteDataSource.filterArticles(tTag))
            .thenThrow(ServerException("Internal Server Failure!"));
        // act
        final result = await repository.filterArticles(tTag);
        // assert
        verify(mockRemoteDataSource.filterArticles(tTag));
        expect(result, equals(Left(ServerFailure("Internal Server Failure!"))));
      },
    );
  });

  group('searchArticles', () {
    const String tQuery = "test";
    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockRemoteDataSource.searchArticles(tQuery))
            .thenAnswer((_) async => tArticles);
        // act
        final result = await repository.searchArticles(tQuery);
        // assert
        verify(mockRemoteDataSource.searchArticles(tQuery));
        expect(result, equals(Right(tArticles)));
      },
    );

    test(
      'should return server failure when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockRemoteDataSource.searchArticles(tQuery))
            .thenThrow(ServerException("Internal Server Failure!"));
        // act
        final result = await repository.searchArticles(tQuery);
        // assert
        verify(mockRemoteDataSource.searchArticles(tQuery));
        expect(result, equals(Left(ServerFailure("Internal Server Failure!"))));
      },
    );
  });
}
