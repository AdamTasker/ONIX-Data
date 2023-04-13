using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnixData.Legacy.Lists
{
  /// <summary>
  /// List 150: Product form
  /// </summary>
  public enum OnixList150
  {
    [XmlEnum("00")] Undefined,
    /// <summary>
    /// Audio recording – detail unspecified
    /// </summary>
    [XmlEnum("AA")] Audio,
    /// <summary>
    /// Audio cassette (analogue)
    /// </summary>
    [XmlEnum("AB")] AudioCassette,
    /// <summary>
    /// Audio compact disc, in any recording format: use for ‘red book’ (conventional audio CD) and SACD, and use coding in Product Form Detail to specify the format, if required
    /// </summary>
    [XmlEnum("AC")] CDAudio,
    /// <summary>
    /// Digital audio tape cassette
    /// </summary>
    [XmlEnum("AD")] DigitalAudioTape,
    /// <summary>
    /// Audio disc (excluding CD-Audio)
    /// </summary>
    [XmlEnum("AE")] AudioDisc,
    /// <summary>
    /// Audio tape (analogue open reel tape)
    /// </summary>
    [XmlEnum("AF")] AudioTape,
    /// <summary>
    /// Sony MiniDisc format
    /// </summary>
    [XmlEnum("AG")] MiniDisc,
    /// <summary>
    /// Audio compact disc with part CD-ROM content, also termed CD-Plus or Enhanced-CD: use for ‘blue book’ and ‘yellow/red book’ two-session discs
    /// </summary>
    [XmlEnum("AH")] CdExtra,
    [XmlEnum("AI")] DvdAudio,
    /// <summary>
    /// Audio recording downloadable online
    /// </summary>
    [XmlEnum("AJ")] DownloadableAudioFile,
    /// <summary>
    /// For example, Playaway audiobook and player: use coding in Product Form Detail to specify the recording format, if required
    /// </summary>
    [XmlEnum("AK")] PreRecordedDigitalAudioPlayer,
    /// <summary>
    /// For example, Audiofy audiobook chip
    /// </summary>
    [XmlEnum("AL")] PreRecordedSdCard,
    /// <summary>
    /// Other audio format not specified by <see cref="AudioCassette"/> to <see cref="PreRecordedSdCard"/>
    /// </summary>
    [XmlEnum("AZ")] OtherAudioFormat,
    /// <summary>
    /// Book – detail unspecified
    /// </summary>
    [XmlEnum("BA")] Book,
    /// <summary>
    /// Hardback or cased book
    /// </summary>
    [XmlEnum("BB")] Hardback,
    /// <summary>
    /// Paperback or other softback book
    /// </summary>
    [XmlEnum("BC")] Paperback,
    /// <summary>
    /// Loose-leaf book
    /// </summary>
    [XmlEnum("BD")] LooseLeaf,
    /// <summary>
    /// Spiral, comb or coil bound book
    /// </summary>
    [XmlEnum("BE")] SpiralBound,
    /// <summary>
    /// Pamphlet or brochure, stapled; German ‘geheftet’. Includes low-extent wire-stitched books bound without a distinct spine (eg many comic books)
    /// </summary>
    [XmlEnum("BF")] Pamphlet,
    [XmlEnum("BG")] LeatherBinding,
    /// <summary>
    /// Child’s book with all pages printed on board
    /// </summary>
    [XmlEnum("BH")] BoardBook,
    /// <summary>
    /// Child’s book with all pages printed on textile
    /// </summary>
    [XmlEnum("BI")] RagBook,
    /// <summary>
    /// Child’s book printed on waterproof material
    /// </summary>
    [XmlEnum("BJ")] BathBook,
    /// <summary>
    /// A book whose novelty consists wholly or partly in a format which cannot be described by any other available code – a ‘conventional’ format code is always to be preferred; one or more Product Form Detail codes, eg from the B2nn group, should be used whenever possible to provide additional description
    /// </summary>
    [XmlEnum("BK")] NoveltyBook,
    /// <summary>
    /// Slide bound book
    /// </summary>
    [XmlEnum("BL")] SlideBound,
    /// <summary>
    /// Extra-large format for teaching etc; this format and terminology may be specifically UK; required as a top-level differentiator
    /// </summary>
    [XmlEnum("BM")] BigBook,
    /// <summary>
    /// A part-work issued with its own ISBN and intended to be collected and bound into a complete book
    /// </summary>
    [XmlEnum("BN")] PartWork,
    /// <summary>
    /// Concertina-folded book or chart, designed to fold to pocket or regular page size: use for German ‘Leporello’
    /// </summary>
    [XmlEnum("BO")] FoldOutBookOrChart,
    /// <summary>
    /// A children’s book whose cover and pages are made of foam
    /// </summary>
    [XmlEnum("BP")] FoamBook,
    /// <summary>
    /// Other book format or binding not specified by <see cref="Hardback"/> to <see cref="FoamBook"/>
    /// </summary>
    [XmlEnum("BZ")] OtherBookFormat,
    /// <summary>
    /// Sheet map – detail unspecified
    /// </summary>
    [XmlEnum("CA")] SheetMap,
    [XmlEnum("CB")] SheetMapFolded,
    [XmlEnum("CC")] SheetMapFlat,
    /// <summary>
    /// See Code List 80 for ‘rolled in tube’
    /// </summary>
    [XmlEnum("CD")] SheetMapRolled,
    /// <summary>
    /// Globe or planisphere
    /// </summary>
    [XmlEnum("CE")] Globe,
    /// <summary>
    /// Other cartographic format not specified by <see cref="SheetMapFolded"/> to <see cref="Globe"/>
    /// </summary>
    [XmlEnum("CZ")] OtherCartographic,
    /// <summary>
    /// 	Digital content delivered on a physical carrier (detail unspecified)
    /// </summary>
    [XmlEnum("DA")] DigitalOnPhysicalCarrier,
    [XmlEnum("DB")] CdRom,
    /// <summary>
    /// CD interactive, use for ‘green book’ discs
    /// </summary>
    [XmlEnum("DC")] CdI,
    [XmlEnum("DE")] GameCartridge,
    /// <summary>
    /// AKA ‘floppy disc’
    /// </summary>
    [XmlEnum("DF")] Diskette,
    [XmlEnum("DI")] DvdRom,
    [XmlEnum("DJ")] SdMemoryCard,
    [XmlEnum("DK")] CompactFlashMemoryCard,
    [XmlEnum("DL")] MemoryStickMemoryCard,
    [XmlEnum("DM")] UsbFlashDrive,
    /// <summary>
    /// Double-sided disc, one side CD-Audio/CD-ROM, other side DVD-Audio/DVD-Video/DVD-ROM (at least one side must be -ROM)
    /// </summary>
    [XmlEnum("DN")] DoubleSidedCdOrDvd,
    /// <summary>
    /// Other carrier of digital content not specified by <see cref="CdRom"/> to <see cref="DoubleSidedCdOrDvd"/>
    /// </summary>
    [XmlEnum("DZ")] OtherDigitalCarrier,
    /// <summary>
    /// Digital content delivered electronically (delivery method unspecified)
    /// </summary>
    [XmlEnum("EA")] DigitalDeliveredElectronically,
    /// <summary>
    /// Digital content available both by download and by online access
    /// </summary>
    [XmlEnum("EB")] DigitalDownloadAndOnline,
    /// <summary>
    /// Digital content accessed online only
    /// </summary>
    [XmlEnum("EC")] DigitalOnline,
    /// <summary>
    /// Digital content delivered by download only
    /// </summary>
    [XmlEnum("ED")] DigitalDownload,
    /// <summary>
    /// Film or transparency – detail unspecified
    /// </summary>
    [XmlEnum("FA")] FilmOrTransparency,
    /// <summary>
    /// Photographic transparencies mounted for projection
    /// </summary>
    [XmlEnum("FC")] Slides,
    /// <summary>
    /// Transparencies for overhead projector
    /// </summary>
    [XmlEnum("FD")] OverheadProjectorTransparencies,
    [XmlEnum("FE")] Filmstrip,
    /// <summary>
    /// Continuous movie film as opposed to filmstrip
    /// </summary>
    [XmlEnum("FF")] Film,
    /// <summary>
    /// Other film or transparency format not specified by <see cref="FilmOrFilmstrip"/> to <see cref="Film"/>
    /// </summary>
    [XmlEnum("FZ")] OtherFilmOrTransparencyFormat,
    /// <summary>
    /// Digital product license (delivery method not encoded)
    /// </summary>
    [XmlEnum("LA")] DigitalProductLicense,
    /// <summary>
    /// Digital product license delivered through the retail supply chain as a physical ‘key’, typically a card or booklet containing a code enabling the purchaser to download the associated product
    /// </summary>
    [XmlEnum("LB")] DigitalProductLicenseKey,
    /// <summary>
    /// Digital product license delivered by email or other electronic distribution, typically providing a code enabling the purchaser to upgrade or extend the license supplied with the associated product
    /// </summary>
    [XmlEnum("LC")] DigitalProductLicenseCode,
    /// <summary>
    /// Microform – detail unspecified
    /// </summary>
    [XmlEnum("MA")] Microform,
    [XmlEnum("MB")] Microfiche,
    /// <summary>
    /// Roll microfilm
    /// </summary>
    [XmlEnum("MC")] Microfilm,
    /// <summary>
    /// Other microform not specified by <see cref="Microfiche"/> or <see cref="Microfilm"/>
    /// </summary>
    [XmlEnum("MZ")] OtherMicroform,
    /// <summary>
    /// Miscellaneous printed material – detail unspecified
    /// </summary>
    [XmlEnum("PA")] MiscellaneousPrint,
    /// <summary>
    /// May use product form detail codes P201 to P204 to specify binding
    /// </summary>
    [XmlEnum("PB")] AddressBook,
    [XmlEnum("PC")] Calendar,
    /// <summary>
    /// Cards, flash cards (eg for teaching reading)
    /// </summary>
    [XmlEnum("PD")] Cards,
    /// <summary>
    /// Copymasters, photocopiable sheets
    /// </summary>
    [XmlEnum("PE")] Copymasters,
    /// <summary>
    /// May use product form detail codes P201 to P204 to specify binding
    /// </summary>
    [XmlEnum("PF")] Diary,
    /// <summary>
    /// Narrow strip-shaped printed sheet used mostly for education or children’s products (eg depicting alphabet, number line, procession of illustrated characters etc). Usually intended for horizontal display
    /// </summary>
    [XmlEnum("PG")] Frieze,
    /// <summary>
    /// Parts for post-purchase assembly
    /// </summary>
    [XmlEnum("PH")] Kit,
    [XmlEnum("PI")] SheetMusic,
    [XmlEnum("PJ")] PostcardBookOrPack,
    /// <summary>
    /// Poster for retail sale – see also <seealso cref="PosterPromotional"/>
    /// </summary>
    [XmlEnum("PK")] Poster,
    /// <summary>
    /// Record book (eg ‘birthday book’, ‘baby book’): binding unspecified; may use product form detail codes P201 to P204 to specify binding
    /// </summary>
    [XmlEnum("PL")] RecordBook,
    /// <summary>
    /// Wallet or folder (containing loose sheets etc): it is preferable to code the contents and treat ‘wallet’ as packaging (List 80), but if this is not possible the product as a whole may be coded as a ‘wallet’
    /// </summary>
    [XmlEnum("PM")] WalletOrFolder,
    [XmlEnum("PN")] PicturesOrPhotographs,
    [XmlEnum("PO")] Wallchart,
    [XmlEnum("PP")] Stickers,
    /// <summary>
    /// A book-sized (as opposed to poster-sized) sheet, usually in color or high quality print
    /// </summary>
    [XmlEnum("PQ")] Plate,
    /// <summary>
    /// A book with all pages blank for the buyer’s own use: may use product form detail codes P201 to P204 to specify binding
    /// </summary>
    [XmlEnum("PR")] NotebookOrBlankBook,
    /// <summary>
    /// May use product form detail codes P201 to P204 to specify binding
    /// </summary>
    [XmlEnum("PS")] Organizer,
    [XmlEnum("PT")] Bookmark,
    /// <summary>
    /// Other printed item not specified by <see cref="AddressBook"/> to <see cref="Bookmark"/>
    /// </summary>
    [XmlEnum("PZ")] OtherPrintedItem,
    /// <summary>
    /// Presentation unspecified: format of product items must be given in &lt;ProductPart&gt;
    /// </summary>
    [XmlEnum("SA")] MultipleItemRetailProduct,
    /// <summary>
    /// Format of product items must be given in &lt;ProductPart&gt;
    /// </summary>
    [XmlEnum("SB")] MultipleItemRetailProductBoxed,
    /// <summary>
    /// Format of product items must be given in &lt;ProductPart&gt;
    /// </summary>
    [XmlEnum("SC")] MultipleItemRetailProductSlipCased,
    /// <summary>
    /// Format of product items must be given in &lt;ProductPart&gt;. Use code XL for a shrink-wrapped pack for trade supply, where the retail items it contains are intended for sale individually
    /// </summary>
    [XmlEnum("SD")] MultipleItemRetailProductShrinkwrapped,
    /// <summary>
    /// Format of product items must be given in &lt;ProductPart&gt;
    /// </summary>
    [XmlEnum("SE")] MultipleItemRetailProductLoose,
    /// <summary>
    /// Multiple item product where subsidiary product part(s) is/are supplied as enclosures to the primary part, eg a book with a CD packaged in a sleeve glued within the back cover. Format of product items must be given in &lt;ProductPart&gt;
    /// </summary>
    [XmlEnum("SF")] MultipleItemRetailProductPartsEnclosed,
    /// <summary>
    /// Video – detail unspecified
    /// </summary>
    [XmlEnum("VA")] Video,
    /// <summary>
    /// eg Laserdisc
    /// </summary>
    [XmlEnum("VF")] Videodisc,
    /// <summary>
    /// DVD video: specify TV standard in List 175
    /// </summary>
    [XmlEnum("VI")] DvdVideo,
    /// <summary>
    /// VHS videotape: specify TV standard in List 175
    /// </summary>
    [XmlEnum("VJ")] VhsVideo,
    /// <summary>
    /// Betamax videotape: specify TV standard in List 175
    /// </summary>
    [XmlEnum("VK")] BetamaxVideo,
    /// <summary>
    /// VideoCD
    /// </summary>
    [XmlEnum("VL")] Vcd,
    /// <summary>
    /// Super VideoCD
    /// </summary>
    [XmlEnum("VM")] Svcd,
    /// <summary>
    /// High definition DVD disc, Toshiba HD DVD format
    /// </summary>
    [XmlEnum("VN")] HdDvd,
    /// <summary>
    /// High definition DVD disc, Sony Blu-ray format
    /// </summary>
    [XmlEnum("VO")] Bluray,
    /// <summary>
    /// Sony Universal Media disc
    /// </summary>
    [XmlEnum("VP")] UmdVideo,
    /// <summary>
    /// China Blue High-Definition, derivative of HD-DVD
    /// </summary>
    [XmlEnum("VQ")] CBHD,
    /// <summary>
    /// Other video format not specified by <see cref="VideoVhsPal"/> to <see cref="CBHD"/>
    /// </summary>
    [XmlEnum("VZ")] OtherVideoFormat,
    /// <summary>
    /// Trade-only material (unspecified)
    /// </summary>
    [XmlEnum("XA")] TradeOnlyMaterial,
    [XmlEnum("XB")] DumpbinEmpty,
    /// <summary>
    /// Dumpbin with contents. ISBN (where applicable) and format of contained items must be given in Product Part
    /// </summary>
    [XmlEnum("XC")] DumpbinFilled,
    [XmlEnum("XD")] CounterpackEmpty,
    /// <summary>
    /// Counterpack with contents. ISBN (where applicable) and format of contained items must be given in Product Part
    /// </summary>
    [XmlEnum("XE")] CounterpackFilled,
    /// <summary>
    /// Promotional poster for display, not for sale – see also <seealso cref="Poster"/>
    /// </summary>
    [XmlEnum("XF")] PosterPromotional,
    [XmlEnum("XG")] ShelfStrip,
    /// <summary>
    /// Promotional piece for shop window display
    /// </summary>
    [XmlEnum("XH")] WindowPiece,
    [XmlEnum("XI")] Streamer,
    [XmlEnum("XJ")] Spinner,
    /// <summary>
    /// Large scale facsimile of book for promotional display
    /// </summary>
    [XmlEnum("XK")] LargeBookDisplay,
    /// <summary>
    /// A quantity pack with its own product code, for trade supply only: the retail items it contains are intended for sale individually. ISBN (where applicable) and format of contained items must be given in Product Part. For products or product bundles supplied individually shrink-wrapped for retail sale, use <seealso cref="MultipleItemRetailProductShrinkwrapped"/>
    /// </summary>
    [XmlEnum("XL")] ShrinkWrappedPack,
    /// <summary>
    /// A quantity pack with its own product code, for trade supply only: the retail items it contains are intended for sale individually. ISBN (where applicable) and format of contained items must be given in Product Part. For products or product bundles boxed individually for retail sale, use <seealso cref="MultipleItemRetailProductBoxed"/>
    /// </summary>
    [XmlEnum("XM")] BoxedPack,
    /// <summary>
    /// Other point of sale material not specified by <see cref="DumpbinEmpty"/> to <see cref="BoxedPack"/>
    /// </summary>
    [XmlEnum("XZ")] OtherPointOfSale,
    /// <summary>
    /// General merchandise – unspecified
    /// </summary>
    [XmlEnum("ZA")] GeneralMerchandise,
    [XmlEnum("ZB")] Doll,
    /// <summary>
    /// Soft or plush toy
    /// </summary>
    [XmlEnum("ZC")] SoftToy,
    [XmlEnum("ZD")] Toy,
    /// <summary>
    /// Board game, or other game (except computer game: see <see cref="GameCartridge"/>)
    /// </summary>
    [XmlEnum("ZE")] Game,
    [XmlEnum("ZF")] Tshirt,
    /// <summary>
    /// Dedicated e-book reading device, typically with mono screen
    /// </summary>
    [XmlEnum("ZG")] EbookReader,
    /// <summary>
    /// General purpose tablet computer, typically with color screen
    /// </summary>
    [XmlEnum("ZH")] TabletComputer,
    /// <summary>
    /// Dedicated audiobook player device, typically including book-related features like bookmarking
    /// </summary>
    [XmlEnum("ZI")] AudiobookPlayer,
    [XmlEnum("ZJ")] Jigsaw,
    [XmlEnum("ZK")] Mug,
    [XmlEnum("ZL")] ToteBag,
    /// <summary>
    /// Other apparel items not specified by <see cref="Doll"/> to <see cref="ToteBag"/>, including promotional or branded scarves, caps, aprons etc
    /// </summary>
    [XmlEnum("ZY")] OtherApparel,
    /// <summary>
    /// Other merchandise not specified by <see cref="Doll"/> to <see cref="OtherApparel"/>
    /// </summary>
    [XmlEnum("ZZ")] OtherMerchandise
  }
}
