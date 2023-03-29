namespace backend.Services;

public interface IBaseCrud<TEntity, Tid> {
  public List<TEntity> GetAll();
  public TEntity? GetOne(Tid id);
  public TEntity? Update(TEntity entity);
  public TEntity Create(TEntity entity);
  public TEntity? Delete(Tid id);
}