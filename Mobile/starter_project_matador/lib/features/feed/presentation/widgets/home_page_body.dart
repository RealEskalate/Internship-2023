import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/feed/presentation/widgets/article_preview_card.dart';
import 'package:matador/features/feed/presentation/widgets/filter_chips.dart';
import 'package:matador/features/feed/presentation/widgets/search_bar.dart';

class HomePageBody extends StatelessWidget {
  const HomePageBody({Key? key, required this.articles}) : super(key: key);
  final List<Article> articles;
  
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 15),
      child: Center(
        child: Column(
          children: [
            SizedBox(
              height: convertPixelToScreenHeight(context, 110),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: const [
                  SearchBar(),
                  FilterChips()
                ],
              ),
            ),
            SizedBox(height: convertPixelToScreenHeight(context, 30)),
            Expanded(
              child: ListView.separated(
                itemCount: articles.length,
                separatorBuilder: (context, index) => SizedBox(
                  height: convertPixelToScreenHeight(context, 25),
                ),
                itemBuilder: (context, index) {
                  final article = articles[index];
                  return ArticlePreviewCard(article: article);
                },
              ),
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Container(
                  margin: const EdgeInsets.symmetric(vertical: 15),
                  width: convertPixelToScreenHeight(context, 50),
                  height: convertPixelToScreenHeight(context, 50),
                  decoration: BoxDecoration(
                    color: defaultButtonColor,
                    borderRadius: BorderRadius.circular(convertPixelToScreenHeight(context, 10)),
                  ),
                  child: const Icon(
                    Icons.add,
                    color: defaultIconColor,
                    size: 30,
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
