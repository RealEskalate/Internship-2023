import 'package:mockito/annotations.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartsmiths/features/article/domain/usecases/get_article.dart';
import './get_article_test.mocks.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

@GenerateMocks([ArticleRepository])
void main() {
  late GetArticle usecase;
  late MockArticleRepository mockArticleRepository;

  setUp(() {
    mockArticleRepository = MockArticleRepository();
    usecase = GetArticle(mockArticleRepository);
  });

  const tid = '1';
  const ttitle = 'title';
  const tsubtitle = 'subTitle';
  const tcontent = 'content';
  final ttags = ['tag1', 'tag2', 'tag3'];
  const tauthorId = '2';

  final tArticle = Article(
    id: tid,
    title: ttitle,
    subTitle: tsubtitle,
    content: tcontent,
    tags: ttags,
    authorId: tauthorId,
  );

  test(
    'should get Article',
    () async {
      when(mockArticleRepository.getArticle(tid))
          .thenAnswer((_) async => Right(tArticle));

      final result = await usecase.call(tid);
      // assert
      expect(result, Right(tArticle));
      verify(mockArticleRepository.getArticle(tid));
      verifyNoMoreInteractions(mockArticleRepository);
    },
  );
}
