import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'package:dartsmiths/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dartsmiths/features/article/data/models/article_model.dart';
import 'package:dartsmiths/features/article/data/repositories/article_repository_impl.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/platform/network_info.dart';

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
      'should return server failure when the call to remote data source is unsuccessful',
      () async {
        // arrange
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
        when(mockRemoteDataSource.GetArticle(tId))
            .thenThrow(ServerFailure());
        // act
        final result = await repository.getArticle(tId);
        // assert
        verify(mockRemoteDataSource.GetArticle(tId));
        expect(result, equals(Left(ServerFailure())));
      },
    );
  });
}

























































// import 'package:dartsmiths/core/error/exception.dart';
// import 'package:dartsmiths/core/error/failures.dart';
// import 'package:dartsmiths/features/article/data/datasources/article_remote_data_source.dart';
// import 'package:dartsmiths/features/article/data/models/article_model.dart';
// import 'package:dartsmiths/features/article/data/repositories/article_repository_impl.dart';
// import 'package:dartsmiths/features/article/domain/entities/article.dart';
// import 'package:dartsmiths/platform/network_info.dart';
// import 'package:dartz/dartz.dart';
// import 'package:flutter_test/flutter_test.dart';
// import 'package:mockito/mockito.dart';

// class MockRemoteDataSource extends Mock
//     implements ArticleRemoteDataSourceImpl {}

// class MockNetworkInfo extends Mock implements NetworkInfo {}

// void main() {
//   late ArticleRepositoryImpl repository;
//   late MockRemoteDataSource mockRemoteDataSource;
//   late MockNetworkInfo mockNetworkInfo;

//   setUp(() {
//     mockRemoteDataSource = MockRemoteDataSource();
//     mockNetworkInfo = MockNetworkInfo();
//     repository = ArticleRepositoryImpl(
//         articleRemoteDataSource: mockRemoteDataSource,
//         networkInfo: mockNetworkInfo);
//   });
//   group('getArticle', () {
//     final tid = '1';
//     final ttitle = 'title';
//     final tsubtitle = 'subTitle';
//     final tcontent = 'content';
//     final ttags = ['tag1', 'tag2', 'tag3'];
//     final tauthorId = '2';

//     final tArticleModel = Article(
//       id: tid,
//       title: ttitle,
//       subTitle: tsubtitle,
//       content: tcontent,
//       tags: ttags,
//       authorId: tauthorId,
//     );

//     final Article tArticle = tArticleModel;

//     test(
//       'should check if the device is online',
//       () async {
//         when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
//         repository.getArticle(tid);
//         verify(mockNetworkInfo.isConnected);
//       },
//     );

//     group('device is online', () {
//       setUp(() {
//         when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
//       });

//       test('should return remote data', () {
//         when(mockRemoteDataSource.GetArticle(tid))
//             .thenAnswer((_) async => tArticleModel);

//         repository.getArticle(tid);
//       });
//     });
//   });
// }


