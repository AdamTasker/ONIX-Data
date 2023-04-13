using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  public enum OnixList78
  {
    /// <summary>
    /// CD ‘red book’ format
    /// </summary>
    [XmlEnum("A101")] CdStandardAudioFormat,
    [XmlEnum("A102")] SacdSuperAudioFormat,
    /// <summary>
    /// MPEG-1/2 Audio Layer III file
    /// </summary>
    [XmlEnum("A103")] Mp3Format,
    /// <summary>
    /// Waveform audio file
    /// </summary>
    [XmlEnum("A104")] WavFormat,
    [XmlEnum("A105")] RealAudioFormat,
    /// <summary>
    /// Windows Media Audio format
    /// </summary>
    [XmlEnum("A106")] WMA,
    /// <summary>
    /// Advanced Audio Coding format
    /// </summary>
    [XmlEnum("A107")] AAC,
    /// <summary>
    /// Vorbis audio format in the Ogg container
    /// </summary>
    [XmlEnum("A108")] OggVorbis,
    /// <summary>
    /// Audio format proprietary to Audible.com
    /// </summary>
    [XmlEnum("A109")] Audible,
    /// <summary>
    /// Free lossless audio codec
    /// </summary>
    [XmlEnum("A110")] FLAC,
    /// <summary>
    /// Audio Interchangeable File Format
    /// </summary>
    [XmlEnum("A111")] AIFF,
    /// <summary>
    /// Apple Lossless Audio Codec
    /// </summary>
    [XmlEnum("A112")] ALAC,
    /// <summary>
    /// Deprecated, as does not meet DAISY 2 standard. Use conventional audiobook codes instead
    /// </summary>
    [XmlEnum("A201")] Daisy2FullAudioWithTitleOnlyAndNoNavigation,
    [XmlEnum("A202")] Daisy2FullAudioWithNavigationAndNoText,
    [XmlEnum("A203")] Daisy2FullAudioWithNavigationAndPartialText,
    [XmlEnum("A204")] Daisy2FullAudioWithNavigationAndFullText,
    /// <summary>
    /// Reading systems may provide full audio via text-to-speech
    /// </summary>
    [XmlEnum("A205")] Daisy2FullTextWithNavigationAndPartialAudio,
    /// <summary>
    /// Reading systems may provide full audio via text-to-speech
    /// </summary>
    [XmlEnum("A206")] Daisy2FullTextWithNavigationAndNoAudio,
    /// <summary>
    /// Deprecated, as does not meet DAISY 3 standard. Use conventional audiobook codes instead
    /// </summary>
    [XmlEnum("A207")] Daisy3FullAudioWithTitleOnlyAndNoNavigation,
    [XmlEnum("A208")] Daisy3FullAudioWithNavigationAndNoText,
    [XmlEnum("A209")] Daisy3FullAudioWithNavigationAndPartialText,
    [XmlEnum("A210")] Daisy3FullAudioWithNavigationAndFullText,
    /// <summary>
    /// Reading systems may provide full audio via text-to-speech
    /// </summary>
    [XmlEnum("A211")] Daisy3FullTextWithNavigationAndSomeAudio,
    /// <summary>
    /// Reading systems may provide full audio via text-to-speech
    /// </summary>
    [XmlEnum("A212")] Daisy3FullTextWithNavigationAndNoAudio,
    [XmlEnum("A301")] StandaloneAudio,
    /// <summary>
    /// Audio intended exclusively for use alongside a printed copy of the book. Most often a children’s product.
    /// Normally contains instructions such as ‘turn the page now’ and other references to the printed item, and is usually sold packaged together with a printed copy
    /// </summary>
    [XmlEnum("A302")] ReadalongAudio,
    /// <summary>
    /// Audio intended for musical accompaniment, eg ‘Music minus one’, etc, often used for music learning. Includes singalong backing audio for musical learning or for Karaoke-style entertainment
    /// </summary>
    [XmlEnum("A303")] PlayalongAudio,
    /// <summary>
    /// Audio intended for language learning, which includes speech plus gaps intended to be filled by the listener
    /// </summary>
    [XmlEnum("A304")] SpeakalongAudio,
    /// <summary>
    /// Audio synchronised to text within an e-publication, for example an EPUB3 with audio overlay. Synchronisation at least at paragraph level, and covering the full content
    /// </summary>
    [XmlEnum("A305")] SynchronisedAudio,
    /// <summary>
    /// Includes 'stereo' where channels are identical
    /// </summary>
    [XmlEnum("A410")] Mono,
    [XmlEnum("A420")] Stereo,
    /// <summary>
    /// Stereo plus low-frequency channel
    /// </summary>
    [XmlEnum("A421")] Stereo2x1,
    /// <summary>
    /// Five-channel audio (including low-frequency channel)
    /// </summary>
    [XmlEnum("A441")] Surround4x1,
    /// <summary>
    /// Six-channel audio (including low-frequency channel)
    /// </summary>
    [XmlEnum("A451")] Surround5x1,
    /// <summary>
    /// In North America, a category of paperback characterized partly by page size (typically from 6¾ up to 7⅛ x 4¼ inches) and partly by target market and terms of trade.
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B101")] MassMarketRackPaperback,
    /// <summary>
    /// In North America, a category of paperback characterized partly by page size and partly by target market and terms of trade. AKA ‘quality paperback’, and including textbooks.
    /// Most paperback books sold in North America except ‘mass-market’ (B101) and ‘tall rack’ (B107) are correctly described with this code.
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B102")] TradePaperbackUS,
    /// <summary>
    /// In North America, a category of paperback characterized by page size and generally used for children’s books.
    /// Use with Product Form code BC.
    /// Note: was wrongly shown as B102 (duplicate entry) in Issue 3
    /// </summary>
    [XmlEnum("B103")] DigestFormatPaperback,
    /// <summary>
    /// In UK, a category of paperback characterized by page size (normally 178 x 111 mm approx).
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B104")] AFormatPaperback,
    /// <summary>
    /// In UK, a category of paperback characterized by page size (normally 198 x 129 mm approx).
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B105")] BFormatPaperback,
    /// <summary>
    /// In UK, a category of paperback characterized partly by size (usually in traditional hardback dimensions), and often used for paperback originals.
    /// Use with Product Form code BC
    /// Note: Replaces ‘C-format’ from former List 8
    /// </summary>
    [XmlEnum("B106")] TradePaperbackUK,
    /// <summary>
    /// In North America, a category of paperback characterised partly by page size (typically 7½ x 4¼ inches) and partly by target market and terms of trade.
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B107")] TallRackPaperback,
    /// <summary>
    /// 210 x 148mm
    /// </summary>
    [XmlEnum("B108")] A5SizeTankobon,
    /// <summary>
    /// Japanese B-series size, 257 x 182 mm
    /// </summary>
    [XmlEnum("B109")] JISB5SizeTankobon,
    /// <summary>
    /// Japanese B-series size, 182 x 128 mm
    /// </summary>
    [XmlEnum("B110")] JISB6SizeTankobon,
    /// <summary>
    /// 148 x 105 mm
    /// </summary>
    [XmlEnum("B111")] A6SizeBunko,
    /// <summary>
    /// Japanese format, 182 x 103 mm or 173 x 105 mm
    /// </summary>
    [XmlEnum("B112")] B40DoriShinsho,
    /// <summary>
    /// A Swedish, Norwegian, French paperback format, of no particular fixed size.
    /// Use with Product Form Code BC
    /// </summary>
    [XmlEnum("B113")] Pocket,
    /// <summary>
    /// A Swedish paperback format.
    /// Use with Product Form Code BC
    /// </summary>
    [XmlEnum("B114")] Storpocket,
    /// <summary>
    /// A Swedish hardback format.
    /// Use with Product Form Code BB
    /// </summary>
    [XmlEnum("B115")] Kartonnage,
    /// <summary>
    /// A Swedish softback format.
    /// Use with Product Form Code BC
    /// </summary>
    [XmlEnum("B116")] Flexband,
    /// <summary>
    /// A softback book in the format of a magazine, usually sold like a book.
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B117")] MookBookazine,
    /// <summary>
    /// Also called ‘Flipback’. A softback book in a specially compact proprietary format with pages printed in landscape on very thin paper and bound along the long (top) edge – see www.dwarsligger.com
    /// </summary>
    [XmlEnum("B118")] Dwarsligger,
    /// <summary>
    /// Japanese format: 188 x 127 mm
    /// </summary>
    [XmlEnum("B119")]	J46Size,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B120")]	J46HenkeiSize,
    /// <summary>
    /// 297 x 210 mm
    /// </summary>
    [XmlEnum("B121")] A4,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B122")] A4HenkeiSize,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B123")] A5HenkeiSize,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B124")] B5HenkeiSize,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B125")] B6HenkeiSize,
    /// <summary>
    /// 257 x 210 mm
    /// </summary>
    [XmlEnum("B126")] ABSize,
    /// <summary>
    /// Japanese B-series size, 128 x 91 mm
    /// </summary>
    [XmlEnum("B127")] JISB7Size,
    /// <summary>
    /// Japanese format, 218 x 152 mm or 227 x 152 mm
    /// </summary>
    [XmlEnum("B128")] KikuSize,
    /// <summary>
    /// Japanese format
    /// </summary>
    [XmlEnum("B129")] KikuHenkeiSize,
    /// <summary>
    /// Japanese B-series size, 364 x 257 mm
    /// </summary>
    [XmlEnum("B130")] JISB4Size,
    /// <summary>
    /// German paperback format, greater than 205 mm high, with flaps.
    /// Use with Product form code BC
    /// </summary>
    [XmlEnum("B131")] PaperbackDE,
    [XmlEnum("B201")] ColoringOrJoinTheDotBook,
    [XmlEnum("B202")] LiftTheFlapBook,
    /// <summary>
    /// DEPRECATED because of ambiguity – use B210, B214 or B215 as appropriate
    /// </summary>
    [XmlEnum("B203")] FuzzyBook,
    /// <summary>
    /// Note: was wrongly shown as B203 (duplicate entry) in Issue 3
    /// </summary>
    [XmlEnum("B204")] MiniatureBook,
    [XmlEnum("B205")] MovingPictureOrFlickerBook,
    [XmlEnum("B206")] PopUpBook,
    [XmlEnum("B207")] ScentedOrSmellyBook,
    [XmlEnum("B208")] SoundStoryOrNoisyBook,
    [XmlEnum("B209")] StickerBook,
    /// <summary>
    /// A book whose pages have a variety of textured inserts designed to stimulate tactile exploration: see also B214 and B215
    /// </summary>
    [XmlEnum("B210")] TouchAndFeelBook,
    /// <summary>
    /// DEPRECATED – use B212 or B213 as appropriate
    /// </summary>
    [XmlEnum("B211")] ToyOrDieCutBook,
    /// <summary>
    /// A book which is cut into a distinctive non-rectilinear shape and/or in which holes or shapes have been cut internally. (‘Die-cut’ is used here as a convenient shorthand, and does not imply strict limitation to a particular production process)
    /// </summary>
    [XmlEnum("B212")] DieCutBook,
    /// <summary>
    /// A book which is also a toy, or which incorporates a toy as an integral part. (Do not, however, use B213 for a multiple-item product which includes a book and a toy as separate items)
    /// </summary>
    [XmlEnum("B213")] BookAsToy,
    /// <summary>
    /// A book whose cover has a soft textured finish, typically over board
    /// </summary>
    [XmlEnum("B214")] SoftToTouchBook,
    /// <summary>
    /// A book with detachable felt pieces and textured pages on which they can be arranged
    /// </summary>
    [XmlEnum("B215")] FuzzyFeltBook,
    /// <summary>
    /// Children’s picture book: use with applicable Product Form code
    /// </summary>
    [XmlEnum("B221")] PictureBook,
    /// <summary>
    /// (aka ‘Star’ book). Tax treatment of products may differ from that of products with similar codes such as Book as toy or Pop-up book)
    /// </summary>
    [XmlEnum("B222")]	CarouselBook,
    /// <summary>
    /// Use with Product Form code BD
    /// </summary>
    [XmlEnum("B301")] LooseLeafSheetsAndBinder,
    /// <summary>
    /// Use with Product Form code BD
    /// </summary>
    [XmlEnum("B302")] LooseLeafBinderOnly,
    /// <summary>
    /// Use with Product Form code BD
    /// </summary>
    [XmlEnum("B303")] LooseLeafSheetsOnly,
    /// <summary>
    /// AKA stitched; for ‘saddle-sewn’, see code B310
    /// </summary>
    [XmlEnum("B304")] Sewn,
    /// <summary>
    /// Including ‘perfect bound’, ‘glued’
    /// </summary>
    [XmlEnum("B305")] UnsewnOrAdhesiveBound,
    /// <summary>
    /// Strengthened cloth-over-boards binding intended for libraries.
    /// Use with Product form code BB
    /// </summary>
    [XmlEnum("B306")] LibraryBinding,
    /// <summary>
    /// Strengthened binding, not specifically intended for libraries
    /// </summary>
    [XmlEnum("B307")] ReinforcedBinding,
    /// <summary>
    /// Must be accompanied by a code specifiying a material, eg ‘half-bound real leather’
    /// </summary>
    [XmlEnum("B308")] HalfBound,
    /// <summary>
    /// Must be accompanied by a code specifiying a material, eg ‘quarter bound real leather’
    /// </summary>
    [XmlEnum("B309")] QuarterBound,
    /// <summary>
    /// AKA ‘saddle-stitched’ or ‘wire-stitched’
    /// </summary>
    [XmlEnum("B310")] SaddleSewn,
    /// <summary>
    /// Round or oval plastic forms in a clamp-like configuration.
    /// Use with Product Form code BE
    /// </summary>
    [XmlEnum("B311")] CombBound,
    /// <summary>
    /// Twin loop metal wire spine.
    /// Use with Product Form code BE
    /// </summary>
    [XmlEnum("B312")] WireO,
    /// <summary>
    /// Cased over Coiled or Wire-O binding.
    /// Use with Product Form code BE and Product Form Detail code B312 or B315
    /// </summary>
    [XmlEnum("B313")] ConcealedWire,
    /// <summary>
    /// Spiral wire bound.
    /// Use with product form code BE.
    /// The default if a spiral binding type is not stated. Cf. Comb and Wire-O binding
    /// </summary>
    [XmlEnum("B314")] CoiledWireBound,
    /// <summary>
    /// Hardcover binding intended for general consumers rather than libraries.
    /// Use with Product form code BB.
    /// The default if a hardcover binding detail is not stated. cf. Library binding
    /// </summary>
    [XmlEnum("B315")] TradeBinding,
    /// <summary>
    /// Covers do not use a distinctive stock, but are the same as the body pages
    /// </summary>
    [XmlEnum("B400")] SelfCover,
    /// <summary>
    /// AKA fabric, linen over boards
    /// </summary>
    [XmlEnum("B401")] ClothOverBoards,
    [XmlEnum("B402")] PaperOverBoards,
    [XmlEnum("B403")] LeatherReal,
    [XmlEnum("B404")] LeatherImitation,
    [XmlEnum("B405")] LeatherBonded,
    [XmlEnum("B406")] Vellum,
    /// <summary>
    /// DEPRECATED – use new B412 or B413 as appropriate
    /// </summary>
    [XmlEnum("B407")] Plastic,
    /// <summary>
    /// DEPRECATED – use new B412 or B414 as appropriate
    /// </summary>
    [XmlEnum("B408")] Vinyl,
    /// <summary>
    /// Cloth, not necessarily over boards – cf B401
    /// </summary>
    [XmlEnum("B409")] Cloth,
    /// <summary>
    /// Spanish ‘simil-tela’
    /// </summary>
    [XmlEnum("B410")] ImitationCloth,
    [XmlEnum("B411")] Velvet,
    /// <summary>
    /// AKA ‘flexibound’.
    /// Use with Product Form code BC
    /// </summary>
    [XmlEnum("B412")] FlexiblePlasticOrVinylCover,
    [XmlEnum("B413")] PlasticCovered,
    [XmlEnum("B414")] VinylCovered,
    /// <summary>
    /// Book, laminating material unspecified: use L101 for ‘whole product laminated’, eg a laminated sheet map or wallchart
    /// </summary>
    [XmlEnum("B415")] LaminatedCover,
    /// <summary>
    /// With card cover (like a typical paperback). As distinct from a self-cover or more elaborate binding
    /// </summary>
    [XmlEnum("B416")] CardCover,
    /// <summary>
    /// Type unspecified
    /// </summary>
    [XmlEnum("B501")] WithDustJacket,
    /// <summary>
    /// Used to distinguish from B503
    /// </summary>
    [XmlEnum("B502")] WithPrintedDustJacket,
    /// <summary>
    /// With translucent paper or plastic protective cover
    /// </summary>
    [XmlEnum("B503")] WithTranslucentDustCover,
    /// <summary>
    /// For paperback with flaps
    /// </summary>
    [XmlEnum("B504")] WithFlaps,
    [XmlEnum("B505")] WithThumbIndex,
    /// <summary>
    /// If the number of markers is significant, it can be stated as free text in <ProductFormDescription>
    /// </summary>
    [XmlEnum("B506")] WithRibbonMarkers,
    [XmlEnum("B507")] WithZipFastener,
    [XmlEnum("B508")] WithButtonSnapFastener,
    /// <summary>
    /// AKA yapp edge?
    /// </summary>
    [XmlEnum("B509")] WithLeatherEdgeLining,
    /// <summary>
    /// With edge trimming such that the front edge is ragged, not neatly and squarely trimmed: AKA deckle edge, feather edge, uncut edge, rough cut
    /// </summary>
    [XmlEnum("B510")] RoughFront,
    /// <summary>
    /// With one or more gatefold or foldout sections bound in
    /// </summary>
    [XmlEnum("B511")] WithFoldout,
    /// <summary>
    /// Pages include extra-wide margin specifically intended for hand-written annotations
    /// </summary>
    [XmlEnum("B512")] WideMargin,
    /// <summary>
    /// Book with attached loop for fixing to baby stroller, cot, chair etc
    /// </summary>
    [XmlEnum("B513")] WithFasteningStrap,
    /// <summary>
    /// With one or more pages perforated and intended to be torn out for use
    /// </summary>
    [XmlEnum("B514")] WithPerforatedPages,
    /// <summary>
    /// A book in which half the content is printed upside-down, to be read the other way round.Also known as a ‘flip-book’, ‘back-to-back’, (fr.) ‘tête-bêche’ (usually an omnibus of two works)
    /// </summary>
    [XmlEnum("B601")] TurnAroundBook,
    /// <summary>
    /// Manga with pages and panels in the sequence of the original Japanese, but with Western text
    /// </summary>
    [XmlEnum("B602")] UnflippedMangaFormat,
    /// <summary>
    /// Text shows syllable breaks
    /// </summary>
    [XmlEnum("B610")] Syllabification,
    /// <summary>
    /// Single letters only.Was formerly identified as UK Braille Grade 1
    /// </summary>
    [XmlEnum("B701")] UKUncontractedBraille,
    /// <summary>
    /// With some letter combinations. Was formerly identified as UK Braille Grade 2
    /// </summary>
    [XmlEnum("B702")] UKContractedBraille,
    /// <summary>
    /// DEPRECATED- use B704/B705 as appropriate instead
    /// </summary>
    [XmlEnum("B703")] USBraille,
    [XmlEnum("B704")] USUncontractedBraille,
    [XmlEnum("B705")] USContractedBraille,
    [XmlEnum("B706")] UnifiedEnglishBraille,
    /// <summary>
    /// Moon embossed alphabet, used by some print-impaired readers who have difficulties with Braille
    /// </summary>
    [XmlEnum("B707")] Moon,
    /// <summary>
    /// Includes RealVideo packaged within a .rm RealMedia container
    /// </summary>
    [XmlEnum("D101")] RealVideoFormat,
    [XmlEnum("D102")] QuicktimeFormat,
    [XmlEnum("D103")] AviFormat,
    [XmlEnum("D104")] WindowsMediaVideoFormat,
    [XmlEnum("D105")] Mpeg4,
    /// <summary>
    /// Use with an applicable Product Form code D*; note that more detail of operating system requirements can be given in a Product Form Feature composite
    /// </summary>
    [XmlEnum("D201")] MSDOS,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D202")] Windows,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D203")] Macintosh,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D204")] UnixOrLinux,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D205")] OtherOperatingSystems,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D206")] PalmOS,
    /// <summary>
    /// Use with an applicable Product Form code D*; see note on D201
    /// </summary>
    [XmlEnum("D207")] WindowsMobile,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D301")] MicrosoftXBox,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D302")] NintendoGameboyColor,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D303")] NintendoGameboyAdvanced,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D304")] NintendoGameboy,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D305")] NintendoGamecube,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D306")] Nintendo64,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D307")] SegaDreamcast,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D308")] SegaGenesisOrMegadrive,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D309")] SegaSaturn,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D310")] SonyPlayStation1,
    /// <summary>
    /// Use with Product Form code DE or DB as applicable
    /// </summary>
    [XmlEnum("D311")] SonyPlayStation2,
    [XmlEnum("D312")] NintendoDualScreen,
    [XmlEnum("D313")] SonyPlayStation3,
    [XmlEnum("D314")] Xbox360,
    [XmlEnum("D315")] NintendoWii,
    [XmlEnum("D316")] SonyPlayStationPortable,
    /// <summary>
    /// Use where a particular e-publication type(specified in <EpubType>) has both reflowable and fixed-format variants
    /// </summary>
    [XmlEnum("E200")] Reflowable,
    /// <summary>
    /// Use where a particular e-publication type(specified in <EpubType>) has both reflowable and fixed-format variants
    /// </summary>
    [XmlEnum("E201")] FixedFormat,
    /// <summary>
    /// All e-publication resources are included within the e-publication package
    /// </summary>
    [XmlEnum("E202")] ReadableOffline,
    /// <summary>
    /// e-publication requires a network connection to access some resources(eg an enhanced e-book where video clips are not stored within the e-publication ‘package’ itself, but are delivered via an internet connection)
    /// </summary>
    [XmlEnum("E203")] RequiresNetworkConnection,
    /// <summary>
    /// Resources(eg images) present in other editions have been removed from this product, eg due to rights issues
    /// </summary>
    [XmlEnum("E204")] ContentRemoved,
    /// <summary>
    /// Use for fixed-format e-books optimised for landscape display.Also include an indication of the optimal screen aspect ratio
    /// </summary>
    [XmlEnum("E210")] Landscape,
    /// <summary>
    /// Use for fixed-format e-books optimised for portrait display.Also include an indication of the optimal screen aspect ratio
    /// </summary>
    [XmlEnum("E211")] Portrait,
    /// <summary>
    /// Use for fixed-format e-books optimised for displays with a 5:4 aspect ratio (eg 1280x1024 pixels etc, assuming square pixels).
    /// Note that aspect ratio codes are NOT specific to actual screen dimensions or pixel counts, but to the ratios between two dimensions or two pixel counts
    /// </summary>
    [XmlEnum("E221")] Ratio5to4,
    /// <summary>
    /// Use for fixed-format e-books optimised for displays with a 4:3 aspect ratio (eg 800x600, 1024x768, 2048x1536 pixels etc)
    /// </summary>
    [XmlEnum("E222")] Ratio4to3,
    /// <summary>
    /// Use for fixed-format e-books optimised for displays with a 3:2 aspect ratio (eg 960x640, 3072x2048 pixels etc)
    /// </summary>
    [XmlEnum("E223")] Ratio3to2,
    /// <summary>
    /// Use for fixed-format e-books optimised for displays with a 16:10 aspect ratio (eg 1440x900, 2560x1600 pixels etc)
    /// </summary>
    [XmlEnum("E224")] Ratio16to10,
    /// <summary>
    /// Use for fixed-format e-books optimised for displays with a 16:9 aspect ratio (eg 1024x576, 1920x1080, 2048x1152 pixels etc)
    /// </summary>
    [XmlEnum("E225")] Ratio16to9,
    /// <summary>
    /// Whole product laminated (eg laminated map, fold-out chart, wallchart, etc): use B415 for book with laminated cover
    /// </summary>
    [XmlEnum("L101")] Laminated,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P101")] DeskCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P102")] MiniCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P103")] EngagementCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P104")] DayByDayCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P105")] PosterCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P106")] WallCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P107")] PerpetualCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P108")] AdventCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P109")] BookmarkCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P110")] StudentCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P111")] ProjectCalendar,
    /// <summary>
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P112")] AlmanacCalendar,
    /// <summary>
    /// A calendar that is not one of the types specified elsewhere.
    /// Use with Product Form code PC
    /// </summary>
    [XmlEnum("P113")] OtherCalendar,
    /// <summary>
    /// A product that is associated with or ancillary to a calendar or organiser, eg a deskstand for a calendar, or an insert for an organiser.
    /// Use with Product Form code PC or PS
    /// </summary>
    [XmlEnum("P114")] OtherCalendarOrOrganiserProduct,
    /// <summary>
    /// Kamishibai / Cantastoria cards
    /// </summary>
    [XmlEnum("P120")] PictureStoryCards,
    /// <summary>
    /// Stationery item in hardback book format
    /// </summary>
    [XmlEnum("P201")] HardbackStationery,
    /// <summary>
    /// Stationery item in paperback / softback book format
    /// </summary>
    [XmlEnum("P202")] PaperbackOrSoftbackStationery,
    /// <summary>
    /// Stationery item in spiral - bound book format
    /// </summary>
    [XmlEnum("P203")] SpiralBoundStationery,
    /// <summary>
    /// Stationery item in leather - bound book format, or other fine binding
    /// </summary>
    [XmlEnum("P204")] LeatherOrFineBindingStationery,
    /// <summary>
    /// For map, poster, wallchart etc
    /// </summary>
    [XmlEnum("P301")] WithHangingStrips,
    /// <summary>
    /// TV standard for video or DVD
    /// </summary>
    [XmlEnum("V201")] PAL,
    /// <summary>
    /// TV standard for video or DVD
    /// </summary>
    [XmlEnum("V202")] NTSC,
    /// <summary>
    /// TV standard for video or DVD
    /// </summary>
    [XmlEnum("V203")] SECAM,
    /// <summary>
    /// Licensed for use in domestic contexts only
    /// </summary>
    [XmlEnum("V220")] HomeUse,
    /// <summary>
    /// Licensed for use in education
    /// </summary>
    [XmlEnum("V221")] ClassroomUse
  }
}
