import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/article/data/datasources/article_local_data_source.dart';
import 'package:dark_knights/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dark_knights/features/article/data/models/article_model.dart';
import 'package:dark_knights/features/article/data/repositories/article_repository_impl.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'article_repository_imple_test.mocks.dart';

@GenerateMocks([ArticleRemoteDataSource, ArticleLocalDataSource, NetworkInfo])
void main() {
  late ArticleRepositoryImpl articleRepositoryImpl;
  late MockArticleRemoteDataSource mockArticleRemoteDataSource;
  late MockArticleLocalDataSource mockArticleLocalDataSource;
  late MockNetworkInfo mockNetworkInfo;

  setUp(
    () {
      mockArticleLocalDataSource = MockArticleLocalDataSource();
      mockArticleRemoteDataSource = MockArticleRemoteDataSource();
      mockNetworkInfo = MockNetworkInfo();
      articleRepositoryImpl = ArticleRepositoryImpl(
        localDataSource: mockArticleLocalDataSource,
        remoteDataSource: mockArticleRemoteDataSource,
        networkInfo: mockNetworkInfo,
      );
    },
  );

  group(
    'getArticles',
    () {
      final tArticleModels = [
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

      test('should check if the device is online', () async {
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockArticleRemoteDataSource.getArticles())
            .thenAnswer((_) async => tArticleModels);
        await articleRepositoryImpl.getArticles();
        verify(mockArticleRemoteDataSource.getArticles()).called(1);
      });

      group(
        'device is online',
        () {
          setUp(() {
            when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
          });
          test(
            'should return remote data when the call to remote data source is successful',
            () async {
              when(mockArticleRemoteDataSource.getArticles())
                  .thenAnswer((_) async => tArticleModels);
              final result = await articleRepositoryImpl.getArticles();
              verify(mockArticleRemoteDataSource.getArticles());
              expect(result, equals(Right(tArticleModels)));
            },
          );
          test(
            'should cache the data locally when the call to remote data is successful',
            () async {
              when(mockArticleRemoteDataSource.getArticles())
                  .thenAnswer((_) async => tArticleModels);
              await articleRepositoryImpl.getArticles();
              verify(mockArticleRemoteDataSource.getArticles());
              verify(mockArticleLocalDataSource.cacheArticles(tArticleModels));
            },
          );

          test(
            '',
            () async {
              when(mockArticleRemoteDataSource.getArticles())
                  .thenThrow(ServerException('Internal Server Failure'));

              final result = await articleRepositoryImpl.getArticles();
              verify(mockArticleRemoteDataSource.getArticles());
              verifyZeroInteractions(mockArticleLocalDataSource);
              expect(
                result,
                equals(Left(ServerFailure('Internal Server Failure'))),
              );
            },
          );
        },
      );
      group('device is offline', () {
        setUp(() {
          when(mockNetworkInfo.isConnected).thenAnswer((_) async => false);
        });

        test(
          'should return last locally cached data when the call to local data is successful',
          () async {
            when(mockArticleLocalDataSource.getLastArticles())
                .thenAnswer((_) async => tArticleModels);
            final result = await articleRepositoryImpl.getArticles();
            verifyNoMoreInteractions(mockArticleRemoteDataSource);
            verify(mockArticleLocalDataSource.getLastArticles());
            expect(result, equals(Right(tArticleModels)));
          },
        );

        test(
          'should return CacheFailure when there is no cached data',
          () async {
            when(mockArticleLocalDataSource.getLastArticles()).thenThrow(
              CacheException('Local Server Failure'),
            );

            final result = await articleRepositoryImpl.getArticles();
            verifyZeroInteractions(mockArticleRemoteDataSource);
            verify(mockArticleLocalDataSource.getLastArticles());
            expect(result, equals(Left(CacheFailure('Local Server Failure'))));
          },
        );
      });
    },
  );
}
