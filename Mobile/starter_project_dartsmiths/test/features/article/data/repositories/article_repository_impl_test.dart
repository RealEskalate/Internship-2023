import 'package:dartsmiths/core/error/exception.dart';
import 'package:dartsmiths/core/network/network_info.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'package:dartsmiths/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dartsmiths/features/article/data/models/article_model.dart';
import 'package:dartsmiths/features/article/data/repositories/article_repository_impl.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/core/error/failures.dart';

import 'article_repository_impl_test.mocks.dart';



@GenerateMocks([NetworkInfo])
@GenerateMocks([ArticleRemoteDataSource])


void main() {
  late ArticleRepositoryImpl repository;
  late MockArticleRemoteDataSource mockRemoteDataSource;
  late MockNetworkInfo mockNetworkInfo;

  setUp(() {
    mockRemoteDataSource = MockArticleRemoteDataSource();
    mockNetworkInfo = MockNetworkInfo();
    repository = ArticleRepositoryImpl(
      articleRemoteDataSource: mockRemoteDataSource,
       networkInfo: mockNetworkInfo,
    );
  });

  group('getArticle', () {
    const tId = '1';
    final tArticleModel = ArticleModel(
      id: tId,
      title: 'Test Article',
      subTitle: 'Test Subtitle',
      content: 'Test Content',
      tags: ['test', 'dart'],
      authorId: '1',
    );
    final Article tArticle = tArticleModel;

    test(
      'should check if the device is online',

      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.GetArticle(tId)).thenAnswer((_) async => tArticleModel);
        // act
        repository.getArticle(tId);
        // assert
        verify(mockNetworkInfo.isConnected);
      },
    );

    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.GetArticle(tId))
            .thenAnswer((_) async => tArticleModel);
        // act
        final result = await repository.getArticle(tId);
        // assert
        verify(mockRemoteDataSource.GetArticle(tId));

        expect(result, equals(Right(tArticle)));
      },
    );

    test(
      'should return server exception when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.GetArticle(tId))
            .thenThrow(ServerException());
        // act
        final result = await repository.getArticle(tId);
        // assert
        verify(mockRemoteDataSource.GetArticle(tId));
        expect(result, equals(Left(ServerFailure())));
      },
    );
  });


  group('postArticle', () {
    const tId = '1';
    final tArticleModel = ArticleModel(
      id: tId,
      title: 'Test Article',
      subTitle: 'Test Subtitle',
      content: 'Test Content',
      tags: ['test', 'dart'],
      authorId: '1',
    );
    final Article tArticle = tArticleModel;

    test(
      'should check if the device is online',

      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.postArticle(tArticleModel)).thenAnswer((_) async => tArticleModel);
        // act
        repository.postArticle(tArticleModel);
        // assert
        verify(mockNetworkInfo.isConnected);
      },
    );

    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.postArticle(tArticleModel))
            .thenAnswer((_) async => tArticleModel);
        // act
        final result = await repository.postArticle(tArticleModel);
        // assert
        verify(mockRemoteDataSource.postArticle(tArticleModel));

        expect(result, equals(Right(tArticle)));
      },
    );

    test(
      'should return server exception when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.postArticle(tArticleModel))
            .thenThrow(ServerException());
        // act
        final result = await repository.postArticle(tArticleModel);
        // assert
        verify(mockRemoteDataSource.postArticle(tArticleModel));
        expect(result, equals(Left(ServerFailure())));
      },
    );
  });

  group('updateArticle', () {
    const tId = '1';
    final tArticleModel = ArticleModel(
      id: tId,
      title: 'Test Article',
      subTitle: 'Test Subtitle',
      content: 'Test Content',
      tags: ['test', 'dart'],
      authorId: '1',
    );
    final Article tArticle = tArticleModel;

    test(
      'should check if the device is online',

      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.updateArticle(tArticleModel)).thenAnswer((_) async => tArticleModel);
        // act
        repository.updateArticle(tArticleModel);
        // assert
        verify(mockNetworkInfo.isConnected);
      },
    );

    test(
      'should return remote data when the call to remote data source is successful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.updateArticle(tArticleModel))
            .thenAnswer((_) async => tArticleModel);
        // act
        final result = await repository.updateArticle(tArticleModel);
        // assert
        verify(mockRemoteDataSource.updateArticle(tArticleModel));

        expect(result, equals(Right(tArticle)));
      },
    );

    test(
      'should return server exception when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.updateArticle(tArticleModel))
            .thenThrow(ServerException());
        // act
        final result = await repository.updateArticle(tArticleModel);
        // assert
        verify(mockRemoteDataSource.updateArticle(tArticleModel));
        expect(result, equals(Left(ServerFailure())));
      },
    );
  });
}


