import 'package:mobile_assessement/features/feed/home/domain/entity/home.dart';
import 'package:mobile_assessement/features/feed/home/domain/repository/home_repository.dart';
import 'package:mobile_assessement/features/feed/home/domain/usecase/home_usecase.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'home_usecase.mocks.dart';


@GenerateMocks([HomeRepository])
void main() {
  late MockHomeRepository mockHomeRepository;
  late Search usecase;
  setUp(() => {
        mockHomeRepository = MockHomeRepository(),
        usecase = Search(homeRepository: mockHomeRepository),
      });
  String city = 'Mexico';
  String country = 'USA';
  int temperature = 28;

  final broadcast1 = Home(city: city, country: country, temperature: temperature);


  final Home home = broadcast1;
  group('Search and GetByCity usecases', () {
    test("Shoud search a data using city ", () async {
      when(mockHomeRepository.search(city))
          .thenAnswer((_) async => Right(home));

      final result = await usecase.call(Params(city: city));
      expect(result, Right(home));
      verify(mockHomeRepository.search(city));
      verifyNoMoreInteractions(mockHomeRepository);
    });
  });
}
