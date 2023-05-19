// import 'package:dartsmiths/features/feed/home/data/datasource/home_remote.dart';
// import 'package:dartsmiths/features/feed/home/data/repository/home_repository.dart';
// import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';
// import 'package:dartz/dartz.dart';
// import 'package:flutter_test/flutter_test.dart';
// import 'package:mockito/annotations.dart';
// import 'package:mockito/mockito.dart';
// import 'home_repository_test.mocks.dart';

// @GenerateMocks([HomeRemoteDataSource])
// void main() {
//   late MockHomeRemoteDataSource mockHomeRemoteDataSource;
//   late HomeRepositoryImpl homeRepositoryImpl;
//   setUp(() => {
//         mockHomeRemoteDataSource = MockHomeRemoteDataSource(),
//         homeRepositoryImpl =
//             HomeRepositoryImpl(homeRemoteDataSource: mockHomeRemoteDataSource)
//       });
//   String tag = "Techs";
//   const homeData = Home(
//       author: 'author',
//       title: 'title',
//       description: 'description',
//       tag: 'Techs',
//       imageUrl: 'imageUrl',
//       dateTime: '2023-05-12T12:00:00');
  
//   test("Should return a valid data", () async {
//     when(mockHomeRemoteDataSource.filterByTag(tag))
//         .thenAnswer((_) async => homeData);
//     final response = await homeRepositoryImpl.filterByTag(tag);
//     expect(response, const Right(homeData));
//     verify(homeRepositoryImpl.filterByTag(tag));
//   });
// }