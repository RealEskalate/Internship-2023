import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';
import 'package:dartsmiths/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartsmiths/features/feed/home/domain/usecase/home_usecase.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'home_test.mocks.dart';

@GenerateMocks([HomeRepository])
void main() {
  late MockHomeRepository mockHomeRepository;
  late Search usecase;
  setUp(() => {
        mockHomeRepository = MockHomeRepository(),
        usecase = Search(homeRepository: mockHomeRepository),
      });
  String term = 'Education';
  String author = 'Jeal';
  String title = 'Education';
  String description = "You can reach your goal if you love working";
  String imageUrl = "https://www.images/fake.jpg";
  String dateTime = "2023-05-12T12:00:00";
  String tag = "Techs";
  final data1 = Home(
      author: author,
      title: title,
      description: description,
      imageUrl: imageUrl,
      dateTime: dateTime,
      tag: tag);
  final data2 = Home(
      author: author,
      title: title,
      description: description,
      imageUrl: imageUrl,
      dateTime: dateTime,
      tag: tag);
  final List<Home> home = [data1, data2];
  group('Search and GetByTag usecases', () {
    test("Shoud search a data using term and tag", () async {
      when(mockHomeRepository.search(term, tag))
          .thenAnswer((_) async => Right(home));

      final result = await usecase.call(Params(tag: tag, term: term));
      expect(result, Right(home));
      verify(mockHomeRepository.search(term, tag));
      verifyNoMoreInteractions(mockHomeRepository);
    });
  });
}
